using System;
using SportStore.Repositories;
using SportStore.Models;

namespace SportStore
{
    class Program
    {
        private static ProductRepository _productRepository = new ProductRepository();

        static void Main(string[] args)
        {
            _productRepository.LoadData();

            while (true)
            {
                Console.Clear();
                GetProducts();
                Console.Write("\n> ");
                Console.WriteLine("Wpisz help zeby zobaczy dostepne komendy");

                Console.Write("\n> ");
                var command = Console.ReadLine();

                if (command == "add")
                {
                    AddProduct();
                }
                else if (command == "exit")
                {
                    break;
                }
                else if (command == "save")
                {
                    _productRepository.SaveData();
                }
                else if (command == "help")
                {                   
                    Console.WriteLine("Ponizej znajduje sie lista dostepnych komend");
                    Console.WriteLine("edit, delete, back, help, add, exit");
                    Console.ReadKey();
                    continue;
                }
                else if (int.TryParse(command, out int id))
                {
                    if (GetProductById(id))
                    {
                        while (true)
                        {
                            Console.Write("\n> ");
                            command = Console.ReadLine();

                            if (command == "edit")
                            {
                                EditProduct(id);
                                break;
                            }
                            else if (command == "delete")
                            {
                                DeleteProductById(id);
                                break;
                            }
                            else if (command == "back")
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Thank you, goodbye.");
            Console.ReadKey();
        }

        static void GetProducts()
        {
            var products = _productRepository.GetProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.GetInfo());
            }
        }

        static bool GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                Console.WriteLine("W naszej bazie danych nie posiadamy informacji od danym produkcie.");
                return false;
            }
            else
            {
                Console.WriteLine($"Id: {product.Id}");
                Console.WriteLine($"Nazwa: {product.Name}");
                Console.WriteLine($"Kategoria: {product.Category}");
                Console.WriteLine($"Data utworzenia: {product.CreatedDate}");
                Console.WriteLine($"Nowy?: {product.IsNew}");
                Console.WriteLine($"Cena: {product.Price}");
                Console.WriteLine($"Ilosc: {product.Quantity}");
                return true;
            }
        }

        static void AddProduct()
        {
            Console.WriteLine("Dodawanie nowego produktu:");

            var product = new Product();
            product.SetName();
            product.SetCategory();
            product.SetIsNew();
            product.SetPrice();
            product.SetQuantity();

            _productRepository.AddProduct(product.Name, product.Category, product.IsNew, product.Price, product.Quantity);
        }

        static void EditProduct(int id)
        {
            Console.WriteLine("Edytowanie produktu:");

            var product = new Product();
            product.SetName();
            product.SetCategory();
            product.SetIsNew();
            product.SetPrice();
            product.SetQuantity();

            _productRepository.EditProduct(id, product.Name, product.Category, product.IsNew, product.Price, product.Quantity);
        }

        static void DeleteProductById(int id)
        {
            _productRepository.DeleteProductById(id);
            Console.WriteLine("Produkt został pomyślnie usunięty.");
        }
    }
}
