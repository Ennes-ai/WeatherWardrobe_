using System;
using System.Collections.Generic;
using System.Linq; // FİLTRELEME İÇİN BU ŞART
using System.Windows.Forms;
using WeatherWardrobe.data;
using WeatherWardrobe.Model;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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


        private void ButtonÖneriGetir_Click(object sender, EventArgs e)
        {
            int disarisiKacDerece = (int)numericHava.Value;

            // 1. Önce hava durumuna uyan TÜM kıyafetleri süz (Eski mantık)
            List<Cloths> havayaUyanlar = GlobalBrain.gardirop
                .Where(k => disarisiKacDerece >= k.MinTemp && disarisiKacDerece <= k.MaxTemp)
                .ToList();

            if (havayaUyanlar.Count == 0)
            {
                MessageBox.Show("Bu havaya uygun hiçbir kıyafetin yok kaptan! Dolaba bir şeyler ekle.", "Gardırop Boş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Kıyafet yoksa işlemi iptal et
            }

            // 2. ZEKA KISMI: Kategorilere göre ayır ve her birinden RASTGELE 1 tane seç
            Random rastgeleSecici = new Random();
            List<Cloths> bugunkuKombin = new List<Cloths>();

            // Üst Giyim Seç
            var ustGiyim = havayaUyanlar
                .Where(k => k.Category == "Üst Giyim")
                .OrderBy(x => rastgeleSecici.Next()) // Listeyi karıştır
                .FirstOrDefault(); // En üsttekini (rastgele olanı) al

            if (ustGiyim != null) bugunkuKombin.Add(ustGiyim);

            // Alt Giyim Seç
            var altGiyim = havayaUyanlar
                .Where(k => k.Category == "Alt Giyim")
                .OrderBy(x => rastgeleSecici.Next())
                .FirstOrDefault();

            if (altGiyim != null) bugunkuKombin.Add(altGiyim);

            // Dış Giyim Seç (Opsiyonel: Sadece dış giyim varsa ekle)
            var disGiyim = havayaUyanlar
                .Where(k => k.Category == "Dış Giyim")
                .OrderBy(x => rastgeleSecici.Next())
                .FirstOrDefault();

            if (disGiyim != null) bugunkuKombin.Add(disGiyim);

            // Ayakkabı Seç (Kategorin "Ayakkabı" ise bunu kullanabilirsin)
            var ayakkabi = havayaUyanlar
                .Where(k => k.Category == "Ayakkabı")
                .OrderBy(x => rastgeleSecici.Next())
                .FirstOrDefault();

            if (ayakkabi != null) bugunkuKombin.Add(ayakkabi);

            // 3. Ekrana Bas! (Sadece seçilen kombini gösterir)
            dgvKombin.DataSource = null;
            dgvKombin.DataSource = bugunkuKombin;

            if (bugunkuKombin.Count < 2)
            {
                MessageBox.Show("Sana tam bir kombin dizemedim. Üst veya Alt giyim eksik olabilir!", "Kombin Eksik", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvKombin_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKombin.SelectedRows.Count > 0)
            {
                Cloths seciliKıyafet = (Cloths)dgvKombin.SelectedRows[0].DataBoundItem;

                if (!string.IsNullOrEmpty(seciliKıyafet.ImagePath))
                {
                    PicÖnİzleme.ImageLocation = seciliKıyafet.ImagePath;
                }
                else
                {
                    PicÖnİzleme.Image = null;
                }
            }
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
    }
}