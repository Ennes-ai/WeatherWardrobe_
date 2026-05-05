**Weather Wardrobe (Ne Giysem?)** 🧥🌧️

Merhabalar, bu proje günlük "bugün havaya göre ne giysem" derdine ufak bir çözüm bulmak için geliştirdiğim bir masaüstü uygulamasıdır. Visual Studio üzerinde C# Windows Forms kullanılarak yazılmıştır. Klasik WinForms'un o gri ve sıkıcı yapısından kurtulmak için arayüz tarafında "Dark" temalı özel bir tasarım uygulandı.

**Özellikler**
***Anlık Hava Durumu Çekme:*** Open-Meteo API kullanarak listeden seçtiğiniz şehrin o anki sıcaklığını ve yağış durumunu canlı olarak getirir.

***Akıllı Kombin Motoru:*** Havayı analiz eder ve veritabanındaki (dolabınızdaki) kıyafetleri sıcaklık/yağmur durumuna göre filtreler. Renk uyumlarına dikkat ederek size mantıklı bir kombin dizer (Yağmur varsa kapüşonlu dış giyim eklemek gibi).

***Dijital Gardırop:*** Kendi eşyalarınızı renk, kategori, minimum/maksimum sıcaklık dayanıklılığı gibi özellikleriyle sisteme kaydedip listeleyebilirsiniz.

**Kullanılan Teknolojiler**
***C# & .NET Windows Forms:*** Ana iskelet ve kodlama.

***MS SQL Server (SSMS):*** Kullanıcı ve kıyafet verilerini tuttuğumuz veritabanı.

***Guna2 UI Framework:*** O standart butonlardan ve tablolardan kurtulup modern arayüz tasarımı yapmak için kullanıldı.

***Open-Meteo API:*** Ücretsiz ve keysiz hava durumu verisi için.

**Kurulum ve Çalıştırma**
Projeyi indirip kendi bilgisayarınızda denemek isterseniz şu adımları izleyebilirsiniz:

Projeyi zip olarak indirin veya klonlayın, ardından Visual Studio ile .sln dosyasını açın.

Tasarım tarafında Guna2 UI kullanıldığı için projeyi açtığınızda hatalar görüyorsanız, NuGet Package Manager üzerinden Guna.UI2.WinForms paketini kurun.

Veritabanı bağlantısı için kendi SQL sunucunuza uygun bir Database oluşturup, C# tarafındaki bağlantı cümleciğini (Connection String) kendi SSMS sunucu adınıza göre güncelleyin.

Üst menüden Build -> Rebuild Solution yapın ve çalıştırın.

Geliştirmeye açıktır, isteyen çatallayıp (fork) üstüne yeni özellikler ekleyebilir.
