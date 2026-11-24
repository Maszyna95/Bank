using Bank;
using System.Globalization;

namespace KontoNaMonety
{
    internal class Automat
    {
        private int[] _iloscMonet = new int[6];

        private decimal _suma = 0;

        private readonly decimal[] _przyjmowaneMonety = new decimal[] { 5, 2, 1, 0.5m, 0.2m, 0.1m };

        int monety5 = 0;
        int monety2 = 0;
        int monety1 = 0;
        int monety05 = 0;
        int monety02 = 0;
        int monety01 = 0;

        int limit = 5;

        // Metoda WrzucMonete
        public void WrzucMonete(KontoBankowe konto1, string moneta)
        {
            bool czyUdanyParse = decimal.TryParse(
                moneta,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal wartoscMonety
            );

            if (!czyUdanyParse)
            {
                Console.WriteLine("Nieudany odczyt monety.");
                return;
            }

            // Sprawdzamy nominał
            for (int i = 0; i < _przyjmowaneMonety.Length; i++)
            {
                if (wartoscMonety == _przyjmowaneMonety[i])
                {
                    // Sprawdzamy, czy jest miejsce na monetę
                    if (_iloscMonet[i] >= 5)
                    {
                        Console.WriteLine("Brak miejsca! Moneta zwrócona.");
                        return;
                    }

                    konto1.Wplac(wartoscMonety);

                    _iloscMonet[i]++;
                    _suma += wartoscMonety;

                    Console.WriteLine($"Moneta przyjęta: {wartoscMonety}");
                    return;
                }
            }

            Console.WriteLine("Zła moneta.");
        }

        // Wyświetlanie liczby monet
        public void PokazMonety()
        {
            for (int i = 0; i < _przyjmowaneMonety.Length; i++)
            {
                Console.WriteLine(
                    $"Monet {_przyjmowaneMonety[i]} zł: {_iloscMonet[i]}"
                );
            }

            Console.WriteLine($"Łączna wartość monet: {_suma} zł");
        }
        public void PokazPrzyjmowaneMonety()
        {
            Console.WriteLine("Dozwolone monety:");

            foreach (decimal moneta in _przyjmowaneMonety)
            {
                Console.Write(moneta + " ");
            }

            Console.WriteLine();
        }

    }
}
