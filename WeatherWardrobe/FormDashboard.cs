using System;
using System.Collections.Generic;
using System.Linq; // FİLTRELEME İÇİN BU ŞART
using System.Windows.Forms;
using WeatherWardrobe.Model;

namespace WeatherWardrobe
{
    public partial class FormDashboard : Form
    {
        // 1. Tüm formun görebileceği geçici gardırop listemiz
        List<Cloths> gardiropListesi = new List<Cloths>();

        public FormDashboard()
        {
            InitializeComponent();
        }

        // 2. Form açıldığında çalışacak kod (Vitrin doluyor)
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            // Sisteme sahte test verileri yüklüyoruz
            gardiropListesi.Add(new Cloths { Name = "Kırmızı Kışlık Mont", Category = "Dış Giyim", MinTemp = -5, MaxTemp = 10, WeatherCondition = "Karlı" });
            gardiropListesi.Add(new Cloths { Name = "Siyah Deri Ceket", Category = "Dış Giyim", MinTemp = 5, MaxTemp = 15, WeatherCondition = "Rüzgarlı" });
            gardiropListesi.Add(new Cloths { Name = "Mavi Kot Pantolon", Category = "Alt Giyim", MinTemp = 10, MaxTemp = 25, WeatherCondition = "Güneşli" });
            gardiropListesi.Add(new Cloths { Name = "Beyaz Tişört", Category = "Üst Giyim", MinTemp = 20, MaxTemp = 40, WeatherCondition = "Güneşli" });

            // Tabloya bu listeyi bağlıyoruz
            dgvKıyagetler.DataSource = gardiropListesi;
        }

        // 3. "Ne Giysem?" Butonuna Tıklandığında Çalışacak Kod
       

        private void ButtonÖneriGetir_Click(object sender, EventArgs e)
        {
            int disarisiKacDerece = (int)numericHava.Value;

            // Zeka Kısmı: Dereceye uyan kıyafetleri bul
            List<Cloths> uygunKiyafetler = gardiropListesi
                .Where(k => disarisiKacDerece >= k.MinTemp && disarisiKacDerece <= k.MaxTemp)
                .ToList();

            // Tabloyu güncelliyoruz
            dgvKıyagetler.DataSource = null;
            dgvKıyagetler.DataSource = uygunKiyafetler;

            if (uygunKiyafetler.Count == 0)
            {
                MessageBox.Show("Bu havaya uygun hiçbir kıyafetin yok kaptan!", "Gardırop Boş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}