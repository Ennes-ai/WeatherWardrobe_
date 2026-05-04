using System;
using System.Windows.Forms;
using WeatherWardrobe.data;
using WeatherWardrobe.Model;

namespace WeatherWardrobe
{
    public partial class FormAddCloth : Form
    {
        private string kıyafetAdı;
        private int maksSıcaklık;
        private int minSıcaklık;
        private string seçilenResimYolu = "";

        public FormAddCloth()
        {
            InitializeComponent();

            // 1. DÜZELTME: Kategorileri elle değil, veritabanından çekiyoruz!
            DbManager db = new DbManager();
            comboKategori.DataSource = db.KategorileriGetir();
            comboKategori.DisplayMember = "CategoryName"; // Ekranda okunacak isim
            comboKategori.ValueMember = "ID";             // SQL'e gidecek ID numarası
        }

        private void KaydetButton_Click(object sender, EventArgs e)
        {
            kıyafetAdı = textKıyafet.Text;
            maksSıcaklık = (int)numericMaksSıcak.Value;
            minSıcaklık = (int)numericMinSıcak.Value;

            // Senin o harika hata kontrol metodun çalışıyor
            if (Check())
            {
                VeritabaninaKaydet();
            }
        }

        // SENİN YAZDIĞIN KUSURSUZ KONTROL METODU (Aynen kaldı)
        private bool Check()
        {
            if (string.IsNullOrWhiteSpace(kıyafetAdı))
            {
                MessageBox.Show("Lütfen kıyafet adını doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (maksSıcaklık < minSıcaklık)
            {
                MessageBox.Show("Maksimum sıcaklık, minimum sıcaklıktan düşük olamaz.", "Sıcaklık Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboKategori.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir kategori seçin.", "Kategori Seçimi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // 2. DÜZELTME: Geçici listeye değil, GERÇEK SQL VERİTABANINA KAYDEDEN KISIM
        private void VeritabaninaKaydet()
        {
            // SQL'e yazı değil ID göndermemiz lazım (Üst giyim değil, 1 numarası gidecek)
            int katID = Convert.ToInt32(comboKategori.SelectedValue);
            int kiminIDsi = GlobalBrain.AktifKullaniciID; // Sistemi Doğukan mı Dilara mı açtıysa onun ID'si!

            DbManager db = new DbManager();
            bool basariliMi = db.KiyafetEkle(kiminIDsi, katID, kıyafetAdı, minSıcaklık, maksSıcaklık, seçilenResimYolu);

            if (basariliMi)
            {
                MessageBox.Show($"{kıyafetAdı} başarıyla gardırobuna eklendi!", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Başarıyla eklenirse pencereyi kapat
            }
        }

        private void KapatButton_Click(object sender, EventArgs e)
        {
            // 3. DÜZELTME: Application.Exit her şeyi kapatır. this.Close sadece bu ufak pencereyi kapatır.
            this.Close();
        }

        private void buttonResimSeç_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Kıyafet Resmi Seç";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                seçilenResimYolu = openFileDialog.FileName;
                PicKiyafet.ImageLocation = seçilenResimYolu;
            }
        }

        // Yanlışlıkla tıklanan boş metot (hata vermesin diye duruyor)
        private void numericMinSıcak_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Kıyafet Resmi Seç";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                seçilenResimYolu = openFileDialog.FileName;
                PicKiyafet.ImageLocation = seçilenResimYolu;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kıyafetAdı = textKıyafet.Text;
            maksSıcaklık = (int)numericMaksSıcak.Value;
            minSıcaklık = (int)numericMinSıcak.Value;

            // Senin o harika hata kontrol metodun çalışıyor
            if (Check())
            {
                VeritabaninaKaydet();
            }
        }

        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {

        }
    }
}