using KontoNaMonety;
using System;

namespace KontoNaMonety
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KontoBankowe konto1 = new KontoBankowe();
            KontoBankowe konto = new KontoBankowe();
            Automat automat = new Automat();
            Bankomat bankomat = new Bankomat();

            bankomat.ZaladujMonety(2m, 10);
            bankomat.ZaladujMonety(5m, 5);


            Console.WriteLine("Wrzucaj monety.");
            Console.WriteLine("Dozwolone: 5, 2, 1, 0.5, 0.2, 0.1");
            Console.WriteLine("Wpisz 'koniec', aby zakończyć. ");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine();
                Console.Write("Wybierz Monety do Wplaty (5, 2, 1, 0.5, 0.2, 0.1) lub 'koniec': ");

                string wpis = Console.ReadLine();

                if (wpis.ToLower() == "koniec")
                {
                    Console.WriteLine();
                    break;
                }

                string[] monety = wpis.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string moneta in monety)
                {
                    automat.WrzucMonete(konto1, moneta);
                }
            }
            Console.WriteLine();
            Console.WriteLine("=== PODSUMOWANIE ===");
            Console.WriteLine($"Numer konta: {konto1.Numer}");
            Console.WriteLine($"Stan konta: {konto1.StanKonta():F2} zł");

            automat.PokazMonety();
            automat.PokazPrzyjmowaneMonety();


            // Ładowanie monet
            bankomat.ZaladujMonety(5m, 10);
            bankomat.ZaladujMonety(2m, 10);
            bankomat.ZaladujMonety(1m, 10);
            bankomat.ZaladujMonety(0.5m, 10);
            bankomat.ZaladujMonety(0.2m, 10);
            bankomat.ZaladujMonety(0.1m, 10);

            // Wyświetlenie stanu
            bankomat.PokazStan();

            // Wypłata
            Console.WriteLine("Ile pieniędzy chcesz wypłacić?");
            int kwotaDoWyplaty = int.Parse(Console.ReadLine());
            if (kwotaDoWyplaty <= 0)
            {
                Console.WriteLine("Nieprawidłowa kwota do wypłaty.");
                return;
            }
            bankomat.Wyplac(konto1, kwotaDoWyplaty);



            // Ponowne wyświetlenie stanu
            bankomat.PokazStan();

        }
    }
}

