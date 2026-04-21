using System;
using System.Data.SqlClient; // MSSQL ile haberleşmek için gereken kütüphane
using System.Windows.Forms;

namespace WeatherWardrobe.Data
{
    public class DbManager
    {
        // SSMS'teki "localhost" ve Windows Kimlik Doğrulaması ayarımızın C# dilindeki karşılığı
        private string connectionString = "Server=localhost;Database=WeatherWardrobe;Trusted_Connection=True;";

        // Bağlantıyı test etmek için kullanacağımız metod
        public bool BaglantiyiTestEt()
        {
            // using bloğu, işlem bitince bağlantıyı otomatik kapatıp belleği temizler (Temiz kod prensibi)
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open(); // Kapıyı açmayı deniyoruz
                    MessageBox.Show("Veritabanı bağlantısı harika çalışıyor kaptan!", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    // Eğer bir hata olursa uygulamanın çökmesi yerine hatayı ekrana yazdırıyoruz
                    MessageBox.Show("Veritabanına bağlanılamadı. Hata: " + ex.Message, "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }aknsndasdndnasdad
        }
    }
}