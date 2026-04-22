using Microsoft.Data.SqlClient;
using System.Data; // <-- BU YENİ EKLENDİ (DataTable için gerekli)

namespace WeatherWardrobe.Data
{
    public class DbManager
    {
        private string connectionString = "Server=localhost;Database=WeatherWardrobe;Trusted_Connection=True;TrustServerCertificate=True;";

        // TEST METODUMUZ (Hatıra olarak kalabilir)
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

        // --- İŞTE GERÇEK BAĞLANTI: KATEGORİLERİ GETİREN METOT ---
        public DataTable KategorileriGetir()
        {
            DataTable tablo = new DataTable();
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                // SQL'den Kategoriler tablosundaki her şeyi seçiyoruz
                string sorgu = "SELECT ID, CategoryName FROM Categories";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    using (SqlDataAdapter adaptor = new SqlDataAdapter(komut))
                    {
                        // Gelen verileri sanal tablomuza dolduruyoruz
                        adaptor.Fill(tablo);
                    }
                }
            }
            return tablo; // Dolu tabloyu C# formuna gönderiyoruz
        }
    }
}