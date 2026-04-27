using System;

namespace CzujnikCzadu
{
    public class CzujnikCzadu1
    {
        public class Odczyt
        {
            public DateTime DataPomiaru { get; set; }
            public int PoziomCzadu { get; set; }

            public Odczyt(DateTime data, int poziom)
            {
                DataPomiaru = data;
                PoziomCzadu = poziom;
            }
        }
        public BateriaCzujnika Bateria { get; private set; }
        public DateTime DataZamontowaniaBaterii { get; private set; }
        public int CzestotliwoscPomiarow { get; private set; } 
        public const int GranicznyPoziomCzadu = 35; 
        public Odczyt OstatniOdczyt { get; private set; }

        public CzujnikCzadu1(BateriaCzujnika bateria, int czestotliwosc)
        {
            Bateria = bateria;
            DataZamontowaniaBaterii = DateTime.Now;
            CzestotliwoscPomiarow = czestotliwosc;
        }
        

        public string SprawdzStanBaterii()
        {
            double zuzycie = Bateria.WyliczProcentZuzycia(DataZamontowaniaBaterii);
            if (zuzycie > 85)
                return $"UWAGA: Zużycie baterii wynosi {zuzycie:F2}%. Należy wymienić baterię!";

            return $"Bateria OK. Zużycie: {zuzycie:F2}%.";
        }

        public void WymienBaterie(BateriaCzujnika nowaBateria)
        {
            Bateria = nowaBateria;
            DataZamontowaniaBaterii = DateTime.Now;
            Console.WriteLine("Bateria została wymieniona na nową.");
        }

        public void UstawCzestotliwosc(int nowyInterwal)
        {
            CzestotliwoscPomiarow = nowyInterwal;
            Console.WriteLine($"Zmieniono częstotliwość pomiarów na: {nowyInterwal}s.");
        }

        public string WykonajPomiar(int poziom)
        {
            OstatniOdczyt = new Odczyt(DateTime.Now, poziom);

            if (poziom > GranicznyPoziomCzadu)
                return $"!!! ALARM !!! Wykryto stężenie czadu: {poziom} ppm! (Limit: {GranicznyPoziomCzadu} ppm)";

            return $"Pomiar: {poziom} ppm - Poziom bezpieczny.";
        }

        public void ResetujAlarm()
        {
            OstatniOdczyt = null;
            Console.WriteLine("Ostatni odczyt został zresetowany. Alarm wyłączony.");
        }

    }
}