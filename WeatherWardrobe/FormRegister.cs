using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherWardrobe
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            if (!Check())
            {
                return;
            }
            string connStr = "Server=.;Database=WeatherWardrobe;Trusted_Connection=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (Username, Password, FirstName, LastName) VALUES (@user, @pass, @ad, @soyad)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@user", txtKullanıcıAdi.Text);
                    cmd.Parameters.AddWithValue("@pass", txtSifre.Text);
                    cmd.Parameters.AddWithValue("@ad", txtAD.Text);
                    cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı! Artık giriş yapabilirsin.", "Başarılı");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private bool Check()
        {
            if (string.IsNullOrEmpty(txtKullanıcıAdi.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adını girin!", "Eksik Bilgi");
                return false;
            }
            else if (string.IsNullOrEmpty(txtSifre.Text))
            {
                MessageBox.Show("Lütfen şifrenizi girin!", "Eksik Bilgi");
                return false;
            }
            else if (string.IsNullOrEmpty(txtAD.Text))
            {
                MessageBox.Show("Lütfen adınızı girin!", "Eksik Bilgi");
                return false;
            }
            else if (string.IsNullOrEmpty(txtSoyad.Text))
            {
                MessageBox.Show("Lütfen soyadınızı girin!", "Eksik Bilgi");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
