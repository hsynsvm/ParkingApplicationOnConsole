using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingMetots pm = new ParkingMetots();

            string secenek = "";

            while (secenek != "4")
            {
                Console.WriteLine("1. Araç Girişi");
                Console.WriteLine("2. Araç Çıkışı");
                Console.WriteLine("3. Giriş Yapan Araçları Listele");
                Console.WriteLine("4. Çıkış");
                Console.Write("Seçiminizi yapınız: ");

                secenek = Console.ReadLine();

                switch (secenek)
                {
                    case "1":
                        pm.aracGirisi();
                        break;
                    case "2":
                        Console.Clear();
                        pm.aracCikisi(secenek);
                        break;
                    case "3":
                        pm.aracListele();
                        break;
                    case "4":
                        Console.WriteLine("Programdan çıkılıyor!");
                        break;
                    default:
                        Console.WriteLine("Geçersiz giriş yaptınız!");
                        break;
                }
            }
        }
    }
}
