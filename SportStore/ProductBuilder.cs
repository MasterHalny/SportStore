using SportStore.Domain.Models;
using System;

namespace SportStore
{
    public class ProductBuilder
    {
        private Product _product;

        public ProductBuilder()
        {
            _product = new Product();
        }

        public string GetInfo()
        {
            return $"[{_product.Id}] {_product.Name} - ({_product.Category}): {_product.Price}";
        }

        public void SetName()
        {
            Console.Write("Nazwa: ");
            _product.Name = Console.ReadLine();
        }

        public void SetCategory()
        {
            Console.Write("Kategoria: ");
            _product.Category = Console.ReadLine();
        }

        public void SetPrice()
        {
            while (true)
            {
                Console.Write("Cena: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    _product.Price = price;
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
                    _product.Quantity = quantity;
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
                    _product.IsNew = true;
                    break;
                }
                else if (isNew == "N")
                {
                    _product.IsNew = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Bledna odpowiedz, uzyj znaku T lub N.");
                    continue;
                }
            }
        }

        public Product Build()
        {
            return _product;
        }
    }
}
