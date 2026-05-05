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
        double sicaklik = 0;
        string[] iller = {
    "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir",
    "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
    "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari",
    "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir",
    "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir",
    "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat",
    "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman",
    "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
};

        public FormDashboard()
        {
            InitializeComponent();
        }


        private void FormDashboard_Load(object sender, EventArgs e)
        {

            gunaSehirler.Items.Clear();
            gunaSehirler.Items.AddRange(iller); // tek satırda tüm liste
            gunaSehirler.SelectedItem = "Eskişehir";

            checkYagmur.AutoCheck = false;


            #region DataGridView 
            guna2DataGridView1.ReadOnly = true;
            // 1. Genel Arka Plan ve Çizgiler (Gece Siyahı)
            guna2DataGridView1.BackgroundColor = Color.FromArgb(24, 24, 25);
            guna2DataGridView1.GridColor = Color.FromArgb(40, 40, 40);
            guna2DataGridView1.BorderStyle = BorderStyle.None;

            // 2. Sütun Başlıkları (Koyu Bordo Zemin, Altın Sarısı Yazı)
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 0, 0);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(212, 175, 55);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(150, 0, 0);
            guna2DataGridView1.ColumnHeadersHeight = 40; // Başlıkları biraz kalınlaştıralım

            // 3. Normal Satırlar (Koyu Gri Zemin, Açık Gri Yazı)
            guna2DataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            guna2DataGridView1.DefaultCellStyle.ForeColor = Color.LightGray;
            // Bir satıra tıklandığında (Seçildiğinde) arkası hafif kan kırmızısı olsun
            guna2DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(64, 0, 0);
            guna2DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            // 4. Okunabilirlik İçin Çift Satır Rengi (Zebra Efekti)
            guna2DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 25);

            // 5. Windows'un Çirkin Standartlarını Kapatma Ayarları
            guna2DataGridView1.EnableHeadersVisualStyles = false; // Kendi renklerimizi zorla
            guna2DataGridView1.RowHeadersVisible = false; // En soldaki gereksiz ok işaretini gizle
            guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Tıklayınca tüm satırı seçsin
            guna2DataGridView1.AllowUserToAddRows = false; // En alttaki boş çirkin satırı kaldır
                                                           // Formun en üstüne giriş yapan kişinin adını yazalım, şık dursun

            // 1. Genel Arka Plan ve Çizgiler (Gece Siyahı)
            dgvKombin.ReadOnly = true;
            dgvKombin.BackgroundColor = Color.FromArgb(24, 24, 25);
            dgvKombin.GridColor = Color.FromArgb(40, 40, 40);
            dgvKombin.BorderStyle = BorderStyle.None;

            // 2. Sütun Başlıkları (Koyu Bordo Zemin, Altın Sarısı Yazı)
            dgvKombin.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 0, 0);
            dgvKombin.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(212, 175, 55);
            dgvKombin.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvKombin.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(150, 0, 0);
            dgvKombin.ColumnHeadersHeight = 40; // Başlıkları biraz kalınlaştıralım

            // 3. Normal Satırlar (Koyu Gri Zemin, Açık Gri Yazı)
            dgvKombin.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvKombin.DefaultCellStyle.ForeColor = Color.LightGray;
            // Bir satıra tıklandığında (Seçildiğinde) arkası hafif kan kırmızısı olsun
            dgvKombin.DefaultCellStyle.SelectionBackColor = Color.FromArgb(64, 0, 0);
            dgvKombin.DefaultCellStyle.SelectionForeColor = Color.White;

            // 4. Okunabilirlik İçin Çift Satır Rengi (Zebra Efekti)
            dgvKombin.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 24, 25);

            // 5. Windows'un Çirkin Standartlarını Kapatma Ayarları
            dgvKombin.EnableHeadersVisualStyles = false; // Kendi renklerimizi zorla
            dgvKombin.RowHeadersVisible = false; // En soldaki gereksiz ok işaretini gizle
            dgvKombin.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Tıklayınca tüm satırı seçsin
            dgvKombin.AllowUserToAddRows = false;
            #endregion
            gunaHosgeldin.Text = "Hoşgeldiniz : " + GlobalBrain.AktifKullaniciAdSoyad;

            // Veritabanı motorunu çalıştır
            DbManager db = new DbManager();
            guna2DataGridView1.DataSource = db.KullaniciKiyafetleriniGetir(GlobalBrain.AktifKullaniciID);

            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



        }

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
        #region Gereksiz
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dgvKombin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvKıyagetler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion
        private void btnYeniKıyafet_Click(object sender, EventArgs e)
        {

            FormAddCloth formAddCloth = new FormAddCloth();
            formAddCloth.ShowDialog();


            DbManager db = new DbManager();
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = db.KullaniciKiyafetleriniGetir(data.GlobalBrain.AktifKullaniciID);
        }

        private void btnNeGiysem_Click(object sender, EventArgs e)
        {

            int sicakliks = (int)sicaklik;
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
        private async void btnHavaDurumu_Click(object sender, EventArgs e)
        {

        }

        private async Task HavaDurumunuÇek(string Sehir)
        {
            if (string.IsNullOrEmpty(Sehir))
            {
                return;
            }
            guna2Progres.Visible = true;
            guna2Progres.Start();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string arananSehir = Uri.EscapeDataString(Sehir);
                    string geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={arananSehir}&count=1&language=tr&format=json";
                    string geoCevap = await client.GetStringAsync(geoUrl);

                    using (JsonDocument geoDoc = JsonDocument.Parse(geoCevap))
                    {
                        if (!geoDoc.RootElement.TryGetProperty("results", out JsonElement sonuclarArray))
                        {
                            MessageBox.Show("Böyle bir şehir bulamadım kaptan! Yazılışını kontrol et.", "Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var sonuclar = sonuclarArray[0];
                        double lat = sonuclar.GetProperty("latitude").GetDouble();
                        double lon = sonuclar.GetProperty("longitude").GetDouble();

                        string enlem = lat.ToString().Replace(",", ".");
                        string boylam = lon.ToString().Replace(",", ".");
                        string havaUrl = $"https://api.open-meteo.com/v1/forecast?latitude={enlem}&longitude={boylam}&current_weather=true";
                        string havaCevap = await client.GetStringAsync(havaUrl);

                        using (JsonDocument havaDoc = JsonDocument.Parse(havaCevap))
                        {
                            double sicaklik = havaDoc.RootElement.GetProperty("current_weather").GetProperty("temperature").GetDouble();

                            int havaKodu = havaDoc.RootElement.GetProperty("current_weather").GetProperty("weathercode").GetInt32();

                            // 3. WMO (Dünya Meteoroloji Örgütü) Kodlarına göre yağmur kontrolü
                            // 51-67 arası: Çiseleme, Yağmur ve Dondurucu Yağmur
                            // 80-99 arası: Sağanak Yağmur, Kar ve Fırtına
                            bool yagmurVarMi = false;
                            if ((havaKodu >= 51 && havaKodu <= 67) || (havaKodu >= 80 && havaKodu <= 99))
                            {
                                yagmurVarMi = true; 
                            }

                           
                            gunaHavaSıcaklık.Text = $"Hava sıcaklığı : {sicaklik}°C";

                            
                            checkYagmur.Checked = yagmurVarMi;

                            // Sadece ekrandaki yazıyı güncelliyoruz, zırt pırt MessageBox çıkmasın
                            gunaHavaSıcaklık.Text = $"Hava sıcaklığı : {sicaklik}°C";

                            guna2Progres.Visible = false;
                            guna2Progres.Stop();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sistemsel bir hata oluştu:\n" + ex.Message, "Hata Detayı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2Progres.Visible = false;
                    guna2Progres.Stop();
                }

            }
        }

        private async void gunaSehirler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sehir = gunaSehirler.SelectedItem.ToString();

            await HavaDurumunuÇek(sehir);
        }
    }
}