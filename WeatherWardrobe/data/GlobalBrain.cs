using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherWardrobe.Model;

namespace WeatherWardrobe.data
{
    public static class GlobalBrain // Başına public static ekledik ki her yerden ulaşılsın
    {
        // Enes'in zekice hamlesi: Tüm kıyafetleri geçici olarak tutacağımız önbellek listesi
        public static List<Cloths> gardirop = new List<Cloths>();

        // BİZİM EKLENTİMİZ: Sisteme kimin giriş yaptığını tüm formlara hatırlatacak hafıza
        public static int AktifKullaniciID { get; set; }
        public static string AktifKullaniciAdSoyad { get; set; }
    }
}