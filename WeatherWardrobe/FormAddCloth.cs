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
        private string kıyafetRengi;
        private bool kapşonlumu;
        private bool suGeçiriyormu;


        public FormAddCloth()
        {
            InitializeComponent();

            // 1. DÜZELTME: Kategorileri elle değil, veritabanından çekiyoruz!
            DbManager db = new DbManager();
            comboKategori.DataSource = db.KategorileriGetir();
            comboKategori.DisplayMember = "CategoryName"; // Ekranda okunacak isim
            comboKategori.ValueMember = "ID";             // SQL'e gidecek ID numarası
        }



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
            if (gunaKıyafetRengi.Text == null)
            {
                MessageBox.Show("Lütfen bir renk seçin.", "Renk Seçimi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void VeritabaninaKaydet()
        {

            int katID = Convert.ToInt32(comboKategori.SelectedValue);
            int kiminIDsi = GlobalBrain.AktifKullaniciID;

            DbManager db = new DbManager();
            bool basariliMi = db.KiyafetEkle(
                userID: kiminIDsi,
                categoryID: katID,
                isim: kıyafetAdı,
                minTemp: minSıcaklık,
                maxTemp: maksSıcaklık,
                resimYolu: seçilenResimYolu,
                kıyafetRengi: kıyafetRengi,
                kapşonlumu: kapşonlumu,
                suGeçiriyormu: suGeçiriyormu
                );

            if (basariliMi)
            {
                MessageBox.Show($"{kıyafetAdı} başarıyla gardırobuna eklendi!", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        #region Gereksiz
        private void numericMinSıcak_ValueChanged(object sender, EventArgs e)
        {
        }
        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        #endregion

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
            kıyafetRengi = gunaKıyafetRengi.Text;
            kapşonlumu = gunaKapşonlumu.Checked;
            suGeçiriyormu = gunaSuGeçiriyormu.Checked;

            // Senin o harika hata kontrol metodun çalışıyor
            if (Check())
            {
                VeritabaninaKaydet();
            }
        }

        
    }
}