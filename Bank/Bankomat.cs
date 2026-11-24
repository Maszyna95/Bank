using System;
using System.Collections.Generic;
using System.Text;

namespace KontoNaMonety
{
    internal class Bankomat
    {
        private decimal[] _nominaly = { 5m, 2m, 1m, 0.5m, 0.2m, 0.1m };

        private int[] _iloscMonet = new int[6];



        public void ZaladujMonety(decimal nominal, int ilosc)
        {
            for (int i = 0; i < _nominaly.Length; i++)
            {
                if (nominal == _nominaly[i])
                {
                    if (ilosc > 0)
                    {
                        _iloscMonet[i] += ilosc;
                        Console.WriteLine($"Załadowano {ilosc} monet po {nominal} zł.");
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa ilość monet.");
                    }

                    return;
                }
            }

            Console.WriteLine("Bankomat nie obsługuje takiego nominału.");
        }
        public void Wyplac(KontoBankowe konto, decimal kwota)
        {

            if (kwota <= 0)
            {
                Console.WriteLine("Nieprawidłowa kwota.");
                return;
            }

            int[] wydaneMonety = new int[_nominaly.Length];

            decimal pozostalo = kwota;

            // Dobieramy monety od największego nominału
            for (int i = 0; i < _nominaly.Length; i++)
            {
                int ileMoznaWziac = (int)(pozostalo / _nominaly[i]);

                if (ileMoznaWziac > _iloscMonet[i])
                {
                    ileMoznaWziac = _iloscMonet[i];
                }

                wydaneMonety[i] = ileMoznaWziac;

                pozostalo -= ileMoznaWziac * _nominaly[i];
            }

            // Sprawdzamy, czy udało się uzbierać całą kwotę
            if (pozostalo != 0)
            {
                Console.WriteLine("Bankomat nie może wydać dokładnej kwoty.");
                return;
            }

            // Próbujemy wypłacić pieniądze z konta
            if (!konto.Wyplac(kwota))
            {
                Console.WriteLine("Brak wystarczających środków na koncie.");
                return;
            }

            // Zmniejszamy liczbę monet w bankomacie
            for (int i = 0; i < _iloscMonet.Length; i++)
            {
                _iloscMonet[i] -= wydaneMonety[i];
            }

            Console.WriteLine($"Wypłacono {kwota} zł.");

            Console.WriteLine("Wydane monety:");

            for (int i = 0; i < wydaneMonety.Length; i++)
            {
                if (wydaneMonety[i] > 0)
                {
                    Console.WriteLine($"{_nominaly[i]} zł - {wydaneMonety[i]} szt.");
                }
            }

        }
        public void PokazStan()
        {
            decimal suma = 0;

            Console.WriteLine("\nStan bankomatu:");

            for (int i = 0; i < _nominaly.Length; i++)
            {
                Console.WriteLine($"{_nominaly[i]} zł: {_iloscMonet[i]} szt.");

                suma += _nominaly[i] * _iloscMonet[i];
            }

            Console.WriteLine($"Łącznie w bankomacie: {suma} zł");
        }
    }
}