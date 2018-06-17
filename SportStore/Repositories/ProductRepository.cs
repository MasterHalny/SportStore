using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportStore.Repositories
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>();

        public ProductRepository()
        {
            var ball = new Product();
            ball.Id = GetNextId();
            ball.Name = "Ball";
            ball.Category = "Little";
            ball.IsNew = true;
            ball.Price = 5.50m;
            ball.Quantity = 100;
            ball.CreatedDate = DateTime.Now;
            _products.Add(ball);

            var gate = new Product();
            gate.Id = GetNextId();
            gate.Name = "Gate";
            gate.Category = "Big";
            gate.IsNew = false;
            gate.Price = 250;
            gate.Quantity = 8;
            gate.CreatedDate = DateTime.Now;
            _products.Add(gate);

            var trainers = new Product();
            trainers.Id = GetNextId();
            trainers.Name = "Adidas";
            trainers.Category = "Little";
            trainers.IsNew = true;
            trainers.Price = 199.99m;
            trainers.Quantity = 100;
            trainers.CreatedDate = DateTime.Now;
            _products.Add(trainers);

            var basket = new Product();
            basket.Id = GetNextId();
            basket.Name = "Nike";
            basket.Category = "Little";
            basket.IsNew = true;
            basket.Price = 10m;
            basket.Quantity = 101;
            basket.CreatedDate = DateTime.Now;
            _products.Add(basket);

            var volleyball = new Product();
            volleyball.Id = GetNextId();
            volleyball.Name = "Puma";
            volleyball.Category = "Little";
            volleyball.IsNew = true;
            volleyball.Price = 18m;
            volleyball.Quantity = 75;
            volleyball.CreatedDate = DateTime.Now;
            _products.Add(basket);
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProductById(int id)
        {
            return _products.SingleOrDefault(x => x.Id == id);
        }

        public void AddProduct(string name, string category, bool isNew, decimal price, int quantity)
        {
            var product = new Product();
            product.Id = GetNextId();
            product.Name = name;
            product.Category = category;
            product.IsNew = isNew;
            product.Price = price;
            product.Quantity = quantity;
            product.CreatedDate = DateTime.Now;
            _products.Add(product);
        }

        public void EditProduct(int id, string name, string category, bool isNew, decimal price, int quantity)
        {
            var product = _products.SingleOrDefault(x => x.Id == id);

            product.Name = name;
            product.Category = category;
            product.IsNew = isNew;
            product.Price = price;
            product.Quantity = quantity;
        }

        public void DeleteProductById(int id)
        {
            var product = _products.SingleOrDefault(x => x.Id == id);
            _products.Remove(product);
        }

        private int GetNextId()
        {
            if (_products == null || _products.Count == 0)
            {
                return 1;
            }
            else
            {
                return _products.Max(x => x.Id) + 1;
            }
        }
    }
}
