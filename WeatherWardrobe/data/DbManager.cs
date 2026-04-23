using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;

namespace WeatherWardrobe.data
{
    public class DbManager
    {
        // 1. DÜZELTME BURADA: Adrese \SQLEXPRESS eklendi ve yolu bozmasın diye başına @ konuldu.
        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=WeatherWardrobe;Trusted_Connection=True;TrustServerCertificate=True;";

        // TEST METODUMUZ (Hatıra olarak kalabilir - Enes'in yazdığı hali)
        public bool BaglantiyiTestEt()
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open();
                    MessageBox.Show("Veritabanı bağlantısı harika çalışıyor kaptan!", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına bağlanılamadı. Hata: " + ex.Message, "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // KATEGORİLERİ GETİREN METOT (Enes'in yazdığı hali)
        public DataTable KategorileriGetir()
        {
            DataTable tablo = new DataTable();
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                string sorgu = "SELECT ID, CategoryName FROM Categories";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    using (SqlDataAdapter adaptor = new SqlDataAdapter(komut))
                    {
                        adaptor.Fill(tablo);
                    }
                }
            }
            return tablo;
        }

        // 2. YENİ EKLENEN METOT: FormLogin ekranında kullanıcıyı kontrol edecek kod
        public DataTable KullaniciGiris(string kullaniciAdi, string sifre)
        {
            DataTable tablo = new DataTable();
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                // SQL Injection hacklerine karşı @ parametreleri ile güvenli sorgu
                string sorgu = "SELECT ID, FirstName, LastName FROM Users WHERE Username = @user AND Password = @pass";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@user", kullaniciAdi);
                    komut.Parameters.AddWithValue("@pass", sifre);

                    using (SqlDataAdapter adaptor = new SqlDataAdapter(komut))
                    {
                        adaptor.Fill(tablo);
                    }
                }
            }
            return tablo;
        }
    }
}