using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; // FİLTRELEME İÇİN BU ŞART
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherWardrobe.data;
using WeatherWardrobe.Model;

namespace WeatherWardrobe
{
    public partial class FormDashboard : Form
    {
        // 1. Tüm formun görebileceği geçici gardırop listemiz
        //List<Cloths> gardiropListesi = new List<Cloths>();

        public FormDashboard()
        {
            InitializeComponent();
        }

        // 2. Form açıldığında çalışacak kod (Vitrin doluyor)
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            // Formun en üstüne giriş yapan kişinin adını yazalım, şık dursun
            this.Text = "Weather Wardrobe - Gardırop: " + GlobalBrain.AktifKullaniciAdSoyad;

            // Veritabanı motorunu çalıştır
            DbManager db = new DbManager();

            // SADECE sisteme giren kişinin kıyafetlerini çekip direkt tabloya basıyoruz!
            dgvKıyagetler.DataSource = db.KullaniciKiyafetleriniGetir(GlobalBrain.AktifKullaniciID);

            // Tablodaki yazılar sıkışmasın, ekranı tam kaplasın diye ufak bir makyaj
            dgvKıyagetler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // 3. "Ne Giysem?" Butonuna Tıklandığında Çalışacak Kod


        // --- 1. GERÇEK MODA ZEKASI (Renk Uyumu Algoritması) ---
        private bool RenkUyumlumu(string ustRenk, string altRenk)
        {
            if (string.IsNullOrEmpty(ustRenk) || string.IsNullOrEmpty(altRenk) || ustRenk == "Belirtilmedi" || altRenk == "Belirtilmedi")
                return true;

            ustRenk = ustRenk.ToLower().Trim();
            altRenk = altRenk.ToLower().Trim();

            // Joker Renkler (Her şeyle uyar)
            string[] jokerRenkler = { "siyah", "beyaz", "gri", "lacivert", "bej", "krem", "kot", "denim", "vizon" };
            if (jokerRenkler.Contains(ustRenk) || jokerRenkler.Contains(altRenk))
            {
                if ((ustRenk == "kahverengi" && altRenk == "siyah") || (ustRenk == "lacivert" && altRenk == "siyah")) return false;
                return true;
            }

            // Şirinler Sendromu İptali (Aynı renk giyilmez)
            if (ustRenk == altRenk) return false;

            // Facia Kombinleri Engelle (Zıt Renkler)
            if ((ustRenk == "kırmızı" && altRenk == "yeşil") || (ustRenk == "yeşil" && altRenk == "kırmızı")) return false;
            if ((ustRenk == "sarı" && altRenk == "mor") || (ustRenk == "mor" && altRenk == "sarı")) return false;
            if ((ustRenk == "turuncu" && altRenk == "mavi") || (ustRenk == "mavi" && altRenk == "turuncu")) return false;

            return true;
        }


        // --- 2. "NE GİYSEM?" BUTONUNA TIKLANINCA ÇALIŞACAK ANA MOTOR ---
        private void ButtonÖneriGetir_Click(object sender, EventArgs e)
        {
            int sicaklik = (int)numericHava.Value;
            bool yagmurVarMi = checkYagmur.Checked;

            DbManager db = new DbManager();
            DataTable tumDolap = db.KullaniciKiyafetleriniGetir(data.GlobalBrain.AktifKullaniciID);

            // 1. ÖN FİLTRE: Havaya uymayanları direkt ele (Böylece yazın kışlık şapka gelmez)
            var havayaUyanlar = tumDolap.AsEnumerable()
                .Where(k => sicaklik >= Convert.ToInt32(k["Min °C"]) && sicaklik <= Convert.ToInt32(k["Max °C"]))
                .ToList();

            if (!havayaUyanlar.Any())
            {
                MessageBox.Show("Bu havaya uygun hiçbir kıyafetin yok kaptan!", "Dolap Boş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Random rnd = new Random();
            DataTable secilenKombin = tumDolap.Clone();

            // --- A. ÜST GİYİM ---
            var ustGiyim = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Üst Giyim").OrderBy(x => rnd.Next()).FirstOrDefault();
            if (ustGiyim != null) secilenKombin.ImportRow(ustGiyim);

            // --- B. ALT GİYİM (Renk Zekası) ---
            var altGiyimler = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Alt Giyim");
            if (ustGiyim != null)
            {
                string ustRenk = ustGiyim["Renk"].ToString();
                var uyumluAltlar = altGiyimler.Where(k => RenkUyumlumu(ustRenk, k["Renk"].ToString())).ToList();
                if (uyumluAltlar.Any()) altGiyimler = uyumluAltlar;
            }
            var altGiyim = altGiyimler.OrderBy(x => rnd.Next()).FirstOrDefault();
            if (altGiyim != null) secilenKombin.ImportRow(altGiyim);

            // --- C. DIŞ GİYİM (Katman & Yağmur Zekası) ---
            if (sicaklik < 20 || yagmurVarMi)
            {
                var disGiyimler = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Dış Giyim");
                if (yagmurVarMi)
                {
                    disGiyimler = disGiyimler.Where(k => Convert.ToBoolean(k["Kapüşonlu"]) == true || Convert.ToBoolean(k["Su Geçirmez"]) == true);
                }
                var disGiyim = disGiyimler.OrderBy(x => rnd.Next()).FirstOrDefault();
                if (disGiyim != null) secilenKombin.ImportRow(disGiyim);
            }

            // --- D. AYAKKABI ---
            var ayakkabi = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Ayakkabı").OrderBy(x => rnd.Next()).FirstOrDefault();
            if (ayakkabi != null) secilenKombin.ImportRow(ayakkabi);

            // ==========================================
            // EFSANE DETAYLAR BÖLÜMÜ (YENİ KATEGORİLER)
            // ==========================================

            // --- E. KEMER (Ayakkabı ile Renk Eşleştirme Kuralı) ---
            var kemerler = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Kemer");
            if (ayakkabi != null && kemerler.Any())
            {
                string ayakkabiRengi = ayakkabi["Renk"].ToString();
                // Önce ayakkabı ile aynı renk kemer var mı diye bak (Gerçek Moda Kuralı)
                var ayniRenkKemer = kemerler.Where(k => k["Renk"].ToString() == ayakkabiRengi).ToList();

                if (ayniRenkKemer.Any()) kemerler = ayniRenkKemer; // Varsa sadece onları kullan
            }
            var kemer = kemerler.OrderBy(x => rnd.Next()).FirstOrDefault();
            if (kemer != null) secilenKombin.ImportRow(kemer);

            // --- F. ÇANTA ---
            var canta = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Çanta").OrderBy(x => rnd.Next()).FirstOrDefault();
            if (canta != null) secilenKombin.ImportRow(canta);

            // --- G. GÖZLÜK (Hava Güzelse Takılır) ---
            if (sicaklik > 15 && !yagmurVarMi)
            {
                var gozluk = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Gözlük").OrderBy(x => rnd.Next()).FirstOrDefault();
                if (gozluk != null) secilenKombin.ImportRow(gozluk);
            }

            // --- H. ŞAPKA (Sıcaklık filtresinden zaten yazlık/kışlık diye elenmişti, direkt seç) ---
            var sapka = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Şapka").OrderBy(x => rnd.Next()).FirstOrDefault();
            if (sapka != null) secilenKombin.ImportRow(sapka);

            // --- I. DİĞER AKSESUARLAR (Saat, Kolye, Bileklik vs.) ---
            var aksesuar = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Aksesuar").OrderBy(x => rnd.Next()).FirstOrDefault();
            if (aksesuar != null) secilenKombin.ImportRow(aksesuar);


            // Kombini Ekrana Bas!
            dgvKombin.DataSource = null;
            dgvKombin.DataSource = secilenKombin;

            // Tablo Makyajı
            dgvKombin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKombin.RowHeadersVisible = false;
            dgvKombin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKombin.AllowUserToAddRows = false;
            dgvKombin.BackgroundColor = System.Drawing.Color.White;

            if (secilenKombin.Rows.Count < 2)
            {
                MessageBox.Show("Tam bir kombin dizemedim, bazı temel parçalar eksik!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // --- 3. KOMBİNDEKİ EŞYAYA TIKLAYINCA RESMİNİ GÖSTEREN MOTOR ---
        // --- 3. KOMBİNDEKİ EŞYAYA TIKLAYINCA RESMİNİ GÖSTEREN MOTOR (Mermi Geçirmez Versiyon) ---
        private void dgvKombin_SelectionChanged(object sender, EventArgs e)
        {
            // Eğer tablo boşsa veya seçili satır yoksa hiç işlem yapmadan çık (Çökmeyi engeller!)
            if (dgvKombin.SelectedRows.Count == 0 || dgvKombin.CurrentRow == null)
            {
                PicÖnİzleme.Image = null;
                return;
            }

            try
            {
                // En Garanti Yöntem: Veriyi arka plan objelerinden değil, direkt tablodaki hücreden çekiyoruz!
                var hucreVerisi = dgvKombin.SelectedRows[0].Cells["ResimYolu"].Value;

                // Hücre boş değilse ve geçerli bir veri varsa
                if (hucreVerisi != null && hucreVerisi != DBNull.Value)
                {
                    string resimYolu = hucreVerisi.ToString();

                    if (!string.IsNullOrWhiteSpace(resimYolu))
                    {
                        PicÖnİzleme.ImageLocation = resimYolu;
                        return; // Resmi yükledik, metottan çıkabiliriz.
                    }
                }

                // Eğer resim yolu boşsa veya yukarıdaki şartlar uymadıysa kutuyu temizle
                PicÖnİzleme.Image = null;
            }
            catch (Exception)
            {
                // Eğer tablo ilk yüklenirken veya yenilenirken anlık bir kayma olursa programın çökmesini engeller
                PicÖnİzleme.Image = null;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Kıyafet Ekleme ekranını aç
            FormAddCloth formAddCloth = new FormAddCloth();
            formAddCloth.ShowDialog(); // ShowDialog, o pencere kapanana kadar alt satıra geçmeyi engeller!

            // 2. PENCERE KAPANDI! (Kullanıcı kıyafeti ekledi ve ana ekrana döndü)
            // Hemen veritabanı motorunu tekrar çalıştırıp en güncel dolabı çekiyoruz:
            DbManager db = new DbManager();
            dgvKıyagetler.DataSource = null; // Önce tabloyu bir temizle
            dgvKıyagetler.DataSource = db.KullaniciKiyafetleriniGetir(data.GlobalBrain.AktifKullaniciID);
        }

        private void dgvKombin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private async void button1_Click_1(object sender, EventArgs e)
        {
            // 1. Kutudaki şehir adını alıyoruz
            string sehir = txtŞehir.Text.Trim();

            if (string.IsNullOrEmpty(sehir))
            {
                MessageBox.Show("Lütfen bir şehir adı girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // EN KRİTİK NOKTA: Türkçe karakterleri internet diline çeviriyoruz (KÜTAHYA -> K%C3%9CTAHYA)
                    string arananSehir = Uri.EscapeDataString(sehir);

                    // --- AŞAMA 1: Şehrin Koordinatlarını Bul ---
                    string geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={arananSehir}&count=1&language=tr&format=json";
                    string geoCevap = await client.GetStringAsync(geoUrl);

                    using (JsonDocument geoDoc = JsonDocument.Parse(geoCevap))
                    {
                        // Şehir gerçekten bulundu mu kontrolü yapıyoruz (Uydurma bir şey yazıldıysa hata vermesin diye)
                        if (!geoDoc.RootElement.TryGetProperty("results", out JsonElement sonuclarArray))
                        {
                            MessageBox.Show("Böyle bir şehir bulamadım kaptan! Yazılışını kontrol et.", "Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // API'den gelen listeden ilk şehrin koordinatlarını çekiyoruz
                        var sonuclar = sonuclarArray[0];
                        double lat = sonuclar.GetProperty("latitude").GetDouble();
                        double lon = sonuclar.GetProperty("longitude").GetDouble();

                        string enlem = lat.ToString().Replace(",", ".");
                        string boylam = lon.ToString().Replace(",", ".");

                        string havaUrl = $"https://api.open-meteo.com/v1/forecast?latitude={enlem}&longitude={boylam}&current_weather=true";

                        // --- AŞAMA 2: Sıcaklığı Çek ---

                        string havaCevap = await client.GetStringAsync(havaUrl);

                        using (JsonDocument havaDoc = JsonDocument.Parse(havaCevap))
                        {
                            // Sıcaklığı çekiyoruz. (Replace ile nokta/virgül karmaşasını çözüyoruz)
                            double sicaklik = havaDoc.RootElement.GetProperty("current_weather").GetProperty("temperature").GetDouble();

                            // 3. Ekrana Yazdır!
                            numericHava.Value = (decimal)sicaklik;
                            MessageBox.Show($"{sehir} için hava durumu başarıyla güncellendi: {sicaklik}°C", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // GERÇEK HATAYI GÖSTER: Artık kendi mesajımızı değil, sistemin verdiği gerçek hatayı yazdırıyoruz ki sorunu bilelim!
                    MessageBox.Show("Sistemsel bir hata oluştu:\n" + ex.Message, "Hata Detayı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvKıyagetler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}