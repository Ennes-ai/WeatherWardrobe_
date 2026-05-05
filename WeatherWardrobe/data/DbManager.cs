using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;

namespace WeatherWardrobe.data
{
    public class DbManager
    {
        // 1. DÜZELTME BURADA: Adrese \SQLEXPRESS eklendi ve yolu bozmasın diye başına @ konuldu.
        private string connectionString = @"Server=.;Database=WeatherWardrobe;Trusted_Connection=True;TrustServerCertificate=True;";

        
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
                string sorgu = "SELECT * FROM Users WHERE Username = @user AND Password = @pass";

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


        // KULLANICININ GARDIROBUNU GETİREN METOT
        public DataTable KullaniciKiyafetleriniGetir(int userID)
        {
            DataTable tablo = new DataTable();
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                // INNER JOIN kullanarak Clothes ve Categories tablolarını birleştiriyoruz.
                // Böylece ekranda "1" yerine "Üst Giyim" yazacak. Hem de sütun isimlerini Türkçe yapıyoruz.
                string sorgu = @"
            SELECT 
                C.Name AS 'Kıyafet Adı',
                Cat.CategoryName AS 'Kategori',
                C.Color AS 'Renk',
                C.WeatherCondition AS 'Hava Durumu',
                C.MinTemp AS 'Min °C',
                C.MaxTemp AS 'Max °C',
                C.IsHooded AS 'Kapüşonlu',
                C.IsWaterproof AS 'Su Geçirmez'
            FROM Clothes C
            INNER JOIN Categories Cat ON C.CategoryID = Cat.ID
            WHERE C.UserID = @userID";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    // @userID parametresine, GlobalBrain'deki ID'yi yollayacağız
                    komut.Parameters.AddWithValue("@userID", userID);

                    using (SqlDataAdapter adaptor = new SqlDataAdapter(komut))
                    {
                        adaptor.Fill(tablo);
                    }
                }
            }
            return tablo;
        }

        // YENİ KIYAFET EKLEME METODU
        public bool KiyafetEkle(
            int userID,
            int categoryID,
            string isim, 
            int minTemp, 
            int maxTemp, 
            string resimYolu,
            string kıyafetRengi,
            bool kapşonlumu,
            bool suGeçiriyormu
            )
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                // Formda olmayan özellikleri (Renk vb.) varsayılan değerlerle SQL'e yolluyoruz ki hata vermesin
                string sorgu = @"INSERT INTO Clothes 
                        (UserID, CategoryID, Name, MinTemp, MaxTemp, ImagePath, Color, WeatherCondition, IsHooded, IsWaterproof) 
                        VALUES 
                        (@userID, @catID, @isim, @minT, @maxT, @resim, @renk, 'Bilinmiyor', @kapşonlu, @suGeçiriyormu)";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    // Verileri güvenli şekilde parametrelere yüklüyoruz
                    komut.Parameters.AddWithValue("@userID", userID);
                    komut.Parameters.AddWithValue("@catID", categoryID);
                    komut.Parameters.AddWithValue("@isim", isim);
                    komut.Parameters.AddWithValue("@minT", minTemp);
                    komut.Parameters.AddWithValue("@maxT", maxTemp);
                    komut.Parameters.AddWithValue("@renk", kıyafetRengi);
                    komut.Parameters.AddWithValue("@kapşonlu", kapşonlumu);
                    komut.Parameters.AddWithValue("@suGeçiriyormu", suGeçiriyormu);

                    // Eğer resim seçilmediyse SQL'e boş (NULL) gönder
                    if (string.IsNullOrEmpty(resimYolu))
                        komut.Parameters.AddWithValue("@resim", DBNull.Value);
                    else
                        komut.Parameters.AddWithValue("@resim", resimYolu);

                    try
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery(); // Ateşle!
                        return true; // Başarılı
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanına eklenirken hata: " + ex.Message);
                        return false; // Başarısız
                    }
                }
            }
        }
    }
}