using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; 
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

            // Veritabanını çalıştır
            DbManager db = new DbManager();
            guna2DataGridView1.DataSource = db.KullaniciKiyafetleriniGetir(GlobalBrain.AktifKullaniciID);

            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



        }

        private bool RenkUyumlumu(string renk1, string renk2)
        {
            if (string.IsNullOrEmpty(renk1) || string.IsNullOrEmpty(renk2) || renk1 == "Belirtilmedi" || renk2 == "Belirtilmedi")
                return true;

            renk1 = renk1.ToLower().Trim();
            renk2 = renk2.ToLower().Trim();

            if (renk1 == renk2) return false; // Şirinler gibi aynı renk gezmek yok (Siyah hariç)

            string[] jokerler = { "siyah", "beyaz", "gri", "kot", "denim", "bej" };

            // Eğer ikisi de joker rengiyse veya biri jokerse %90 uyar
            if (jokerler.Contains(renk1) || jokerler.Contains(renk2))
            {
                // Göz kanatan istisnalar: Siyah üstüne lacivert veya kahverengi giyilmez
                if ((renk1 == "siyah" && (renk2 == "lacivert" || renk2 == "kahverengi")) ||
                    (renk2 == "siyah" && (renk1 == "lacivert" || renk1 == "kahverengi")))
                    return false;

                return true;
            }

            // Facia zıtlıklar iptal
            if ((renk1 == "kırmızı" && (renk2 == "yeşil" || renk2 == "pembe")) || (renk2 == "kırmızı" && (renk1 == "yeşil" || renk1 == "pembe"))) return false;
            if ((renk1 == "sarı" && renk2 == "mor") || (renk2 == "sarı" && renk1 == "mor")) return false;
            if ((renk1 == "turuncu" && renk2 == "mavi") || (renk2 == "turuncu" && renk1 == "mavi")) return false;

            return false; // Çok riskli iki renk denk geldiyse (örn: Bordo ve Turkuaz) direkt reddet, joker arasın
        }
        private string RenkTipi(string renk)
        {
            if (string.IsNullOrEmpty(renk)) return "Bilinmiyor";
            renk = renk.ToLower().Trim();

            string[] koyular = { "siyah", "lacivert", "kahverengi", "bordo", "antrasit", "gri", "koyu" };
            string[] aciklar = { "beyaz", "bej", "krem", "ekru", "pembe", "lila", "açık", "kemik", "sarı" };

            if (koyular.Any(k => renk.Contains(k))) return "Koyu";
            if (aciklar.Any(a => renk.Contains(a))) return "Açık";
            return "Canlı"; // Kırmızı, Yeşil, Mavi vb.
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
            int anlikSicaklik = (int)this.sicaklik;
            bool yagmurVarMi = checkYagmur.Checked;

            DbManager db = new DbManager();
            DataTable tumDolap = db.KullaniciKiyafetleriniGetir(GlobalBrain.AktifKullaniciID);

            // 1. ÖN FİLTRE: Havaya Uyanlar Havuzu
            var havayaUyanlar = tumDolap.AsEnumerable()
                .Where(k => anlikSicaklik >= Convert.ToInt32(k["Min °C"]) && anlikSicaklik <= Convert.ToInt32(k["Max °C"]))
                .ToList();

            if (!havayaUyanlar.Any())
            {
                MessageBox.Show("Bu havaya uygun hiçbir kıyafetin yok kaptan!", "Dolap Boş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Random rnd = new Random();
            DataTable secilenKombin = tumDolap.Clone();

            // MANYAK YAPAY ZEKA KIYAFET ASİSTANI

            //1. ALT GİYİM (Sıcaklık Zekası)
            var altGiyimler = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Alt Giyim").ToList();

            // Eğer hava çok sıcaksa (25+), öncelikli olarak Şort ara!
            if (anlikSicaklik >= 25)
            {
                var sortlar = altGiyimler.Where(k => k["Kıyafet Adı"].ToString().ToLower().Contains("şort")).ToList();
                if (sortlar.Any()) altGiyimler = sortlar;
            }

            var altGiyim = altGiyimler.OrderBy(x => rnd.Next()).FirstOrDefault();
            string altRenk = altGiyim != null ? altGiyim["Renk"].ToString() : "Belirtilmedi";
            string altTon = RenkTipi(altRenk); // Koyu mu Açık mı?
            if (altGiyim != null) secilenKombin.ImportRow(altGiyim);


            //2. ÜST GİYİM (Kontrast Zekası) 
            var ustGiyimler = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Üst Giyim");
            if (altGiyim != null)
            {
                // Önce renkler çarpışmasın diye ana filtreden geçir
                var uyumluUstler = ustGiyimler.Where(k => RenkUyumlumu(k["Renk"].ToString(), altRenk)).ToList();

                // Pantolon Koyu ise Üstü Açık renk bulmaya çalış (Denge yarat)
                if (uyumluUstler.Any())
                {
                    var kontrastUstler = uyumluUstler.Where(k => RenkTipi(k["Renk"].ToString()) != altTon).ToList();

                    // Eğer zıt tonda bir şey bulabildiyse onu kullan, bulamadıysa normallerden devam et
                    if (kontrastUstler.Any() && rnd.Next(0, 100) > 30) // %70 ihtimalle kontrast giydirir
                    {
                        ustGiyimler = kontrastUstler;
                    }
                    else
                    {
                        ustGiyimler = uyumluUstler;
                    }
                }
            }
            var ustGiyim = ustGiyimler.OrderBy(x => rnd.Next()).FirstOrDefault();
            string ustRenk = ustGiyim != null ? ustGiyim["Renk"].ToString() : "Belirtilmedi";
            if (ustGiyim != null) secilenKombin.ImportRow(ustGiyim);


            //3. DIŞ GİYİM (Yagmur zekası)
            if (anlikSicaklik < 20 || yagmurVarMi)
            {
                var disGiyimler = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Dış Giyim").ToList();

                if (yagmurVarMi)
                    disGiyimler = disGiyimler.Where(k => Convert.ToBoolean(k["Kapüşonlu"]) == true || Convert.ToBoolean(k["Su Geçirmez"]) == true).ToList();

                // Hava buz gibiyse (5 dereceden az) , "Mont, Kaban, Palto, Parka" ara!
                if (anlikSicaklik <= 5)
                {
                    var agirKislilar = disGiyimler.Where(k =>
                        k["Kıyafet Adı"].ToString().ToLower().Contains("mont") ||
                        k["Kıyafet Adı"].ToString().ToLower().Contains("kaban") ||
                        k["Kıyafet Adı"].ToString().ToLower().Contains("palto") ||
                        k["Kıyafet Adı"].ToString().ToLower().Contains("parka")).ToList();

                    if (agirKislilar.Any()) disGiyimler = agirKislilar;
                }

                // Ceket rengi, tişörtle çarpışmasın
                if (ustGiyim != null)
                {
                    var uyumluCeketler = disGiyimler.Where(k => RenkUyumlumu(k["Renk"].ToString(), ustRenk)).ToList();
                    if (uyumluCeketler.Any()) disGiyimler = uyumluCeketler;
                }

                var disGiyim = disGiyimler.OrderBy(x => rnd.Next()).FirstOrDefault();
                if (disGiyim != null) secilenKombin.ImportRow(disGiyim);
            }


            //4. AYAKKABI VE KEMER (Takım Zekası)
            var ayakkabilar = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Ayakkabı");
            if (altGiyim != null)
            {
                var uyumluAyakkabilar = ayakkabilar.Where(k => RenkUyumlumu(k["Renk"].ToString(), altRenk)).ToList();
                if (uyumluAyakkabilar.Any()) ayakkabilar = uyumluAyakkabilar;
            }
            var ayakkabi = ayakkabilar.OrderBy(x => rnd.Next()).FirstOrDefault();
            string ayakkabiRengi = ayakkabi != null ? ayakkabi["Renk"].ToString() : "Belirtilmedi";
            if (ayakkabi != null) secilenKombin.ImportRow(ayakkabi);

            var kemerler = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Kemer");
            if (ayakkabi != null && kemerler.Any())
            {
                var ayniRenkKemer = kemerler.Where(k => k["Renk"].ToString().ToLower() == ayakkabiRengi.ToLower()).ToList();
                if (ayniRenkKemer.Any()) kemerler = ayniRenkKemer;
            }
            var kemer = kemerler.OrderBy(x => rnd.Next()).FirstOrDefault();
            if (kemer != null) secilenKombin.ImportRow(kemer);


            //5. AKSESUARLAR VE ŞAPKA (Kutup Zekası)
            var canta = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Çanta").OrderBy(x => rnd.Next()).FirstOrDefault();
            if (canta != null) secilenKombin.ImportRow(canta);

            if (anlikSicaklik >= 18 && !yagmurVarMi)
            {
                var gozluk = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Gözlük").OrderBy(x => rnd.Next()).FirstOrDefault();
                if (gozluk != null) secilenKombin.ImportRow(gozluk);
            }

            var sapka = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Şapka").OrderBy(x => rnd.Next()).FirstOrDefault();
            if (sapka != null) secilenKombin.ImportRow(sapka);

            var aksesuarlar = havayaUyanlar.Where(k => k["Kategori"].ToString() == "Aksesuar").ToList();

            // Eğer hava buz gibiyse eldiven veya atkı bulmaya zorla
            if (anlikSicaklik <= 5)
            {
                var kisAksesuarlari = aksesuarlar.Where(k =>
                    k["Kıyafet Adı"].ToString().ToLower().Contains("atkı") ||
                    k["Kıyafet Adı"].ToString().ToLower().Contains("eldiven")).ToList();

                if (kisAksesuarlari.Any()) aksesuarlar = kisAksesuarlari;
            }

            var secilenAksesuar = aksesuarlar.OrderBy(x => rnd.Next()).FirstOrDefault();
            if (secilenAksesuar != null) secilenKombin.ImportRow(secilenAksesuar);

            //Ekrana ver
            dgvKombin.DataSource = null;
            dgvKombin.DataSource = secilenKombin;
            dgvKombin.ClearSelection();

            if (secilenKombin.Rows.Count < 2)
                MessageBox.Show("Tam bir kombin dizemedim, dolapta yeterli uygun kıyafet yok!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            this.sicaklik = havaDoc.RootElement.GetProperty("current_weather").GetProperty("temperature").GetDouble();
                            int havaKodu = havaDoc.RootElement.GetProperty("current_weather").GetProperty("weathercode").GetInt32();

                            // (Dünya Meteoroloji Örgütü) Kodlarına göre yağmur kontrolü
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