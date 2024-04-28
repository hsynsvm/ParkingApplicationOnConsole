using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApplication
{
    public class AracBilgisi
    {
        public string Plaka {  get; set; }
        public DateTime GirisZamani;   
        public DateTime CikisZamani { get; set; }
    }
    public class ParkingMetots
    {
        private AracBilgisi[] araclar;
        public double saatlikUcret = 5.0;
        static Random random = new Random();

        public ParkingMetots()
        {
            araclar = new AracBilgisi[0];
        }

        public void aracGirisi()
        {
            Console.Write("Araç Plakasını Giriniz: ");
            string plaka = Console.ReadLine();

            DateTime girisZamani = RastgeleGirisZamani();

            AracBilgisi yeniArac = new AracBilgisi { Plaka = plaka, GirisZamani = RastgeleGirisZamani() };

            AracBilgisi[] gecici = new AracBilgisi[araclar.Length + 1];
            for (int i = 0; i < araclar.Length; i++)
            {
                gecici[i] = araclar[i];
            }

            gecici[gecici.Length - 1] = yeniArac;
            araclar = gecici;

            Console.WriteLine($"Araç {plaka} plakalı {yeniArac.GirisZamani} tarihinde otoparka giriş yaptı.");
        }
        public void aracCikisi(string plaka)
        {
            Console.Write("Araç plakasını giriniz: ");
            string girilenPlaka = Console.ReadLine();

            AracBilgisi cikisYapanArac = null;
            foreach (var arac in araclar)
            {
                if (arac.Plaka == girilenPlaka)
                {
                    cikisYapanArac = arac;
                    break;
                }
            }

            if (cikisYapanArac == null)
            {
                Console.WriteLine("Bu araç otoparkta bulunmamaktadır.");
                return;
            }

            DateTime cikisZamani = DateTime.Now; 
            TimeSpan parkSuresi = cikisZamani - cikisYapanArac.GirisZamani;

            double ucret = Math.Ceiling(parkSuresi.TotalHours) * saatlikUcret + 50;
            Console.WriteLine($"Araç {girilenPlaka} {cikisZamani} tarihinde otoparktan çıkış yaptı.");
            Console.WriteLine($"Ücret: {ucret} TL");

            AracBilgisi[] eskiAraclar = new AracBilgisi[araclar.Length - 1];
            int j = 0;
            for (int i = 0; i < araclar.Length; i++)
            {
                if (araclar[i].Plaka != girilenPlaka)
                {
                    eskiAraclar[j] = araclar[i];
                    j++;
                }
            }
            araclar = eskiAraclar;
        }
        public void aracListele()
        {
            Console.WriteLine("Otoparktaki Araçlar:");
            foreach (var arac in araclar)
            {
                Console.WriteLine($"Plaka: {arac.Plaka}, Giriş Zamanı: {arac.GirisZamani}");
            }
        }
        static DateTime RastgeleGirisZamani()
        {
            // Rastgele bir tarih ve saat oluşturmak için kullanılabilir
            DateTime start = new DateTime(2024, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range)).AddHours(random.Next(24)).AddMinutes(random.Next(60)).AddSeconds(random.Next(60));
        }
    }

    
    
}
