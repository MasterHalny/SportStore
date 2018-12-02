using System;

namespace SportStore.Filters
{
    public class ProductsFilter
    {
        public string Category { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }

        public void SetCategory()
        {
            Console.Write("Kategoria: ");
            Category = Console.ReadLine();
        }

        public void SetPriceFrom()
        {
            while (true)
            {
                Console.Write("Cena od: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal priceFrom))
                {
                    PriceFrom = priceFrom;
                    break;
                }
                else
                {
                    Console.WriteLine("Bledna odpowiedz, wpisz poprawna liczbe.");
                    continue;
                }
            }
        }

        public void SetPriceTo()
        {
            while (true)
            {
                Console.Write("Cena do: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal priceTo))
                {
                    PriceTo = priceTo;
                    break;
                }
                else
                {
                    Console.WriteLine("Bledna odpowiedz, wpisz poprawna liczbe.");
                    continue;
                }
            }
        }

        public void ClearFilters()
        {
            Category = "";
            PriceFrom = 0;
            PriceTo = 0;
        }
    }
}
