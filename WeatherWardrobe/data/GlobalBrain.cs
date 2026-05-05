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
        
        public static List<Cloths> gardirop = new List<Cloths>();


        public static int AktifKullaniciID { get; set; }
        public static string AktifKullaniciAdSoyad { get; set; }
    }
}