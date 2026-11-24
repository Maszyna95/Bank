using System;

namespace KontoNaMonety
{
    internal class KontoBankowe
    {
        private decimal _saldo;
        private readonly string _numer;

        private static int _licznikKont = 1;

        public string Numer
        {
            get { return _numer; }
        }

        public KontoBankowe()
        {
            _numer = $"KB{_licznikKont:D4}";
            _licznikKont++;
        }

        public void Wplac(decimal kwota)
        {
            _saldo += kwota;
        }
        public bool Wyplac(decimal kwota)
        {
            if (kwota <= 0 || kwota > _saldo)
            {
                Console.WriteLine("Wypłata nieudana. Nieprawidłowa kwota lub brak środków.");
                return false;
            }

            _saldo -= kwota;

            Console.WriteLine($"Wypłacono: {kwota} zł");
            return true;
        }

        public decimal StanKonta()
        {
            return _saldo;
        }

        //public decimal PokazHistorieWplat()
        //{

        //}
    }
}
