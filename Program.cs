using CzujnikCzadu;
using System;

namespace CzujnikCzadu
{
    class Program
    {
        static void Main(string[] args)
        {
            BateriaCzujnika duracell = new BateriaCzujnika("Duracell", 365);
            CzujnikCzadu1 Czujnik = new CzujnikCzadu1(duracell, 60);

            Console.WriteLine("--- TEST CZUJNIKA ---");

            Console.WriteLine(Czujnik.SprawdzStanBaterii());

            Czujnik.UstawCzestotliwosc(30);

            Console.WriteLine(Czujnik.WykonajPomiar(10));


            Console.WriteLine(Czujnik.WykonajPomiar(50));


            Czujnik.ResetujAlarm();


            BateriaCzujnika energizer = new BateriaCzujnika("Energizer", 500);
            Czujnik.WymienBaterie(energizer);

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
