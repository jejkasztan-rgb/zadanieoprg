using System;

namespace CzujnikCzadu
{
    public class BateriaCzujnika
    {
        public string NazwaProducenta { get; set; }
        public int CzasDzialaniaWDniach { get; set; }

        public BateriaCzujnika(string nazwa, int czas)
        {
            NazwaProducenta = nazwa;
            CzasDzialaniaWDniach = czas;
        }

        public double WyliczProcentZuzycia(DateTime dataZamontowania)
        {
            TimeSpan roznica = DateTime.Now - dataZamontowania;
            double dniUzytkowania = roznica.TotalDays;


            double zuzycie = (dniUzytkowania / CzasDzialaniaWDniach) * 100;

            return Math.Min(zuzycie, 100);
        }
    }
}