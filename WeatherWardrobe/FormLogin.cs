using System;
using System.Data;
using System.Windows.Forms;
using WeatherWardrobe.data; // DbManager ve GlobalBrain'e ulaşmak için bu klasörü ekliyoruz

namespace WeatherWardrobe
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void GirisButton_Click(object sender, EventArgs e)
        {
            // 1. Textbox'lardan kullanıcının yazdığı verileri alıyoruz
            string kullaniciAdi = gunaKullanıcıAdi.Text;
            string sifre = GunaSifre.Text;

            // Eğer boş bıraktıysa veritabanını hiç yormadan direkt uyaralım
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Kanka kullanıcı adı ve şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Kodu burada kes, aşağı inmesin
            }

            // 2. Veritabanı motorumuzu (Köprüyü) çalıştırıyoruz
            DbManager db = new DbManager();
            DataTable sonuc = db.KullaniciGiris(kullaniciAdi, sifre);

            // 3. GERÇEK KONTROL: Eğer veritabanında böyle biri varsa (gelen satır sayısı 0'dan büyükse)
            if (sonuc.Rows.Count > 0)
            {
                // GİRİŞ BAŞARILI! 
                // SQL'den gelen ID ve Ad-Soyad bilgilerini projenin beynine (GlobalBrain) kazıyoruz
                GlobalBrain.AktifKullaniciID = Convert.ToInt32(sonuc.Rows[0]["ID"]);
                GlobalBrain.AktifKullaniciAdSoyad = sonuc.Rows[0]["FirstName"].ToString() + " " + sonuc.Rows[0]["LastName"].ToString();

                MessageBox.Show("Sisteme hoş geldin, " + GlobalBrain.AktifKullaniciAdSoyad + "!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Enes'in Dashboard'a geçiş kodları aynen kalıyor
                FormDashboard formDashboard = new FormDashboard();
                formDashboard.Show();
                this.Hide();
            }
            else
            {
                // GİRİŞ BAŞARISIZ! (Böyle biri SQL'de yok)
                MessageBox.Show("Kullanıcı adı veya şifre yanlış kanka, veritabanında bulamadık!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextKullanıcıAdi_TextChanged(object sender, EventArgs e)
        {
            // Burası şimdilik boş kalabilir, Enes buraya ileride belki "yazarken harfleri büyütme" falan ekler
        }

        private void ButtonKayıtOl_Click(object sender, EventArgs e)
        {
            
        }
        #region Gereksiz
        private void TextKullanıcıAdi_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void TextŞifre_TextChanged(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        #endregion

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            // 1. Textbox'lardan kullanıcının yazdığı verileri alıyoruz
            guna2ProgressIndicator1.Visible = true;
            guna2ProgressIndicator1.Start();
            string kullaniciAdi = gunaKullanıcıAdi.Text;
            string sifre = GunaSifre.Text;

            // Eğer boş bıraktıysa veritabanını hiç yormadan direkt uyaralım
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Kanka kullanıcı adı ve şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Kodu burada kes, aşağı inmesin
            }

            // 2. Veritabanı motorumuzu (Köprüyü) çalıştırıyoruz
            DbManager db = new DbManager();
            DataTable sonuc = db.KullaniciGiris(kullaniciAdi, sifre);

            // 3. GERÇEK KONTROL: Eğer veritabanında böyle biri varsa (gelen satır sayısı 0'dan büyükse)
            if (sonuc.Rows.Count > 0)
            {
                // GİRİŞ BAŞARILI! 
                // SQL'den gelen ID ve Ad-Soyad bilgilerini projenin beynine (GlobalBrain) kazıyoruz
                GlobalBrain.AktifKullaniciID = Convert.ToInt32(sonuc.Rows[0]["ID"]);
                GlobalBrain.AktifKullaniciAdSoyad = sonuc.Rows[0]["FirstName"].ToString() + " " + sonuc.Rows[0]["LastName"].ToString();

                MessageBox.Show("Sisteme hoş geldin, " + GlobalBrain.AktifKullaniciAdSoyad + "!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Enes'in Dashboard'a geçiş kodları aynen kalıyor
                FormDashboard formDashboard = new FormDashboard();
                formDashboard.Show();
                guna2ProgressIndicator1.Stop();
                guna2ProgressIndicator1.Visible = false;
                this.Hide();
            }
            else
            {
                // GİRİŞ BAŞARISIZ! (Böyle biri SQL'de yok)
                MessageBox.Show("Kullanıcı adı veya şifre yanlış kanka, veritabanında bulamadık!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ProgressIndicator1.Stop();
                guna2ProgressIndicator1.Visible = false;
            }
        }

        private void gunaKayıtOL_Click(object sender, EventArgs e)
        {
            FormRegister frm = new FormRegister();
            frm.ShowDialog();
        }
    }
}