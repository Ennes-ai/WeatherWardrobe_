namespace WeatherWardrobe
{
    class ProjectDuide
    {
    }

    /*
    📘 WEATHER WARDROBE - PROJE MİMARİ VE GELİŞTİRME DÖKÜMANI
Sürüm: 1.0.0
Ekip = Enes&Doğukan

1. PROJE ÖZETİ VE VİZYON
WeatherWardrobe, kullanıcıların kişisel gardıroplarını dijital ortama taşıyan, hava durumuna ve sıcaklık değerlerine göre kullanıcılara ne giymeleri gerektiği konusunda akıllı filtreleme sunan ilişkisel veritabanı destekli bir masaüstü (Windows Forms) yazılımıdır.

Proje, "Her kullanıcıya ayrı tablo" gibi amatör yaklaşımları reddeder; bunun yerine kurumsal SaaS (Software as a Service) projelerinde kullanılan İlişkisel Veritabanı (Relational Database) ve Çoklu Kullanıcı (Multi-tenant) mimarisiyle inşa edilmiştir.

2. KULLANILAN TEKNOLOJİLER (TECH STACK)
Geliştirme Ortamı: Visual Studio

Programlama Dili: C# (.NET)

Arayüz Teknolojisi: Windows Forms (WinForms)

Veritabanı Motoru: Microsoft SQL Server (Yerel / Localhost)

Veritabanı Yönetim Aracı: SQL Server Management Studio (SSMS)

Veri Erişim Katmanı: ADO.NET (Microsoft.Data.SqlClient)

Versiyon Kontrol ve Takım Çalışması: Git & GitHub

3. TAKIM ÇALIŞMASI VE SENKRONİZASYON PROTOKOLÜ
Ekip, fiziksel olarak aynı ağda olmadığından ve bulut sunucu maliyeti/karmaşası istenmediğinden, profesyonel bir Asenkron Geliştirme Modeli uygulanmaktadır.

GitHub Kullanımı: C# kodları ve arayüz dosyaları otomatik olarak GitHub üzerinden birleştirilir (Merge).

Veritabanı Eşitleme (SQL Scripting): Veritabanı tablolarında, kolonlarında veya mimarisinde yapılan her değişiklik Doğukağan tarafından bir .sql (Script) dosyası haline getirilir. Bu dosya GitHub'daki DatabaseScripts klasörüne yüklenir. Enes bu dosyayı çekip (Pull) kendi yerel SSMS'inde çalıştırarak veritabanı iskeletini milisaniyeler içinde eşitler.

Sahte Veri (Mocking): Veritabanı entegrasyonu tamamlanana kadar, C# tarafında arayüz geliştirmeleri durmaz. Gerekli veriler kod içindeki geçici listelerden (statik) sağlanır, DB hazır olduğunda tek satır kodla SQL'e bağlanır.

4. VERİTABANI MİMARİSİ (ER KAVRAMSAL MODELİ)
Sistem 3 temel tablodan oluşur. Merkezde Clothes tablosu yer alır ve Users ile Categories tablolarına Yabancı Anahtar (Foreign Key) ile bağlanır.

Tablo 1: Users (Kullanıcılar)
Kullanıcıların sisteme giriş (Login) bilgilerini ve kişisel detaylarını tutar.

ID (INT) - Birincil Anahtar (Primary Key), Otomatik Artan

Username (NVARCHAR) - Benzersiz (Unique), Giriş adı

Password (NVARCHAR) - Şifre

FirstName, LastName (NVARCHAR) - Ad, Soyad

Age (INT) - Yaş

Gender (NVARCHAR) - Cinsiyet

Tablo 2: Categories (Kategoriler)
Sistemin filtreleme omurgasıdır. Sabit verilerdir (Seed Data).

ID (INT) - Birincil Anahtar (Primary Key)

CategoryName (NVARCHAR) - Kategori Adı (Üst Giyim, Alt Giyim vb.)

Tablo 3: Clothes (Kıyafetler - Ana Gardırop)
Tüm kullanıcıların kıyafetlerinin toplandığı devasa veri havuzudur. Her kıyafetin kime ve hangi kategoriye ait olduğu etiketlenir.

ID (INT) - Birincil Anahtar (Primary Key), Otomatik Artan

UserID (INT) - FOREIGN KEY (Hangi kullanıcının kıyafeti?)

CategoryID (INT) - FOREIGN KEY (Hangi kategoriye ait?)

Name (NVARCHAR) - Kıyafetin Adı

MinTemp, MaxTemp (INT) - Giyilebilecek min/maks sıcaklık (Örn: -5 ile 10 derece arası)

WeatherCondition (NVARCHAR) - Hava durumu etiketi (Güneşli, Yağmurlu, Karlı)

ImagePath (NVARCHAR) - Uygulama içinde gösterilecek fotoğrafın dizin yolu

5. PROJE KLASÖR YAPISI VE KOD MİMARİSİ
Proje, spagetti (karışık) kodlamayı önlemek adına "Katmanlı Mimari" mantığına yakın dizayn edilmiştir:

📂 WeatherWardrobe.sln (Ana Çözüm Dosyası)

📂 Data

DbManager.cs: Veritabanı bağlantı dizesini (Connection String) ve merkezi SQL komutlarını barındıran çekirdek sınıf.

📂 DatabaseScripts

01_Master_Architecture.sql: Doğukağan'ın hazırladığı ve takımın DB iskeletini eşitlediği kurulum betiği.

📂 Images (Kullanıcıların yükleyeceği kıyafet fotoğraflarının yerel kopyalarının tutulacağı klasör).

📄 FormLogin.cs: Kullanıcı giriş ekranı.

📄 FormDashboard.cs: Ana gardırop ekranı ve filtreleme merkezi.

📄 FormAddCloth.cs: Yeni kıyafet ekleme menüsü.

6. UYGULAMA EKRANLARI VE İŞ AKIŞI (USER FLOW)
Ekran 1: Kimlik Doğrulama (Login Form)
Görsel: Kullanıcı Adı ve Şifre için iki TextBox (şifre karakterleri * ile gizlenmiş), "Giriş Yap" ve "Kayıt Ol" butonları.

İşlem: DbManager, girilen bilgileri Users tablosunda sorgular. Eşleşme varsa, o kullanıcının ID değeri global bir değişkene atanır (Session mantığı) ve Ana Ekran açılır.

Ekran 2: Ana Gardırop (Dashboard Form)
Görsel: Sol tarafta filtreleme seçenekleri (Açılır liste ile Kategori, TextBox ile Sıcaklık, RadioButton ile Hava Durumu). Sağ tarafta ise devasa bir DataGridView veya resimli bir FlowLayoutPanel (Kıyafetlerin listelendiği yer).

İşlem: Sayfa yüklendiğinde SQL'e şu komut gider: SELECT * FROM Clothes WHERE UserID = [AktifKullaniciID]. Filtreleme butonlarına basıldığında bu SQL sorgusuna AND MinTemp <= X gibi şartlar eklenerek liste anlık olarak güncellenir.

Ekran 3: Kıyafet Ekleme (Add Cloth Form)
Görsel: Kıyafet Adı (TextBox), Kategori (ComboBox - SQL'den çekilir), Min/Max Sıcaklık (NumericUpDown), Hava Durumu (ComboBox), Resim Seç (Button & PictureBox).

İşlem: Tüm alanlar doldurulup "Kaydet" denildiğinde bir INSERT INTO Clothes komutu oluşturulur. Kritik nokta: C# kodu, arka planda giriş yapmış olan kullanıcının ID'sini bu komuta gizlice ekleyerek (UserID) kıyafetin başkasına gitmesini engeller.

7. GELİŞTİRME YOL HARİTASI (ROADMAP)
Aşama (Tamamlandı): Git entegrasyonu, repoların kurulması, eski ve hatalı paketlerin temizlenip Microsoft.Data.SqlClient altyapısının kurulması.

Aşama (Mevcut Durum): Mimarinin tasarlanması. Doğukağan'ın SQL betiklerini oluşturup DatabaseScripts üzerinden Enes'e iletmesi. Enes'in "Mock" statik verilerle UI (Arayüz) tasarımlarına başlaması.

Aşama (Entegrasyon): Statik kodların silinip, gerçek SqlCommand ve SqlDataAdapter yapılarıyla veri çekme ve formlara veri basma (DataBinding) işlemlerinin yapılması.

Aşama (CRUD Operasyonları): Insert (Ekle), Update (Güncelle), Delete (Sil) algoritmalarının C# ve SQL tarafında kodlanması.

Aşama (Filtreleme & Gelişmiş Mantık): "Dışarısı 5 derece, ne giysem?" butonunun kodlanması. (SQL'de Between operatörü kullanarak filtreleme).

HAZIRLAYAN: WeatherWardrobe Geliştirme Ekibi
TARİH: Nisan 2026

    */
}
