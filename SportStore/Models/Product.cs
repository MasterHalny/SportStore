using System;

namespace SportStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsNew { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }

        public string GetInfo()
        {
            return $"[{Id}] {Name} - ({Category}): {Price}";
        }

        public void SetName()
        {
            Console.Write("Nazwa: ");
            Name = Console.ReadLine();
        }

        public void SetCategory()
        {
            Console.Write("Kategoria: ");
            Category = Console.ReadLine();
        }

        public void SetPrice()
        {
            while (true)
            {
                Console.Write("Cena: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Price = price;
                    break;
                }
                else
                {
                    Console.WriteLine("Bledna odpowiedz, wpisz poprawna liczbe.");
                    continue;
                }
            }
        }

        public void SetQuantity()
        {
            while (true)
            {
                Console.Write("Ilosc: ");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Quantity = quantity;
                    break;
                }
                else
                {
                    Console.WriteLine("Bledna odpowiedz, wpisz poprawna liczbe.");
                    continue;
                }
            }
        }

        public void SetIsNew()
        {
            while (true)
            {
                Console.Write("Czy produkt jest nowy (T/N): ");
                var isNew = Console.ReadLine();
                if (isNew == "T")
                {
                    IsNew = true;
                    break;
                }
                else if (isNew == "N")
                {
                    IsNew = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Bledna odpowiedz, uzyj znaku T lub N.");
                    continue;
                }
            }
        }
    }
}
