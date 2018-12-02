using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using SportStore.Domain.Models;
using Newtonsoft.Json;

namespace SportStore.Domain.Repositories
{
    public class ProductRepository
    {
        private const string _filePath = @"J:\shop\sportsstoredb.json"; 
        private List<Product> _products = new List<Product>();

        public List<Product> GetProducts(string category,decimal priceFrom, decimal priceTo)
        {
            var query = _products.AsQueryable();

            if (category != "" && category != null)
            {
                query = query.Where(product => product.Category == category);
            }

            if (priceFrom != 0)
            {
                query = query.Where(product => product.Price >=priceFrom);
            }

            if (priceTo != 0)
            {
                query = query.Where(product => product.Price <= priceTo);
            }

            return query.ToList();
        }

        public void LoadData()
        {
            var json = File.ReadAllText(_filePath);
            _products = JsonConvert.DeserializeObject<List<Product>>(json);

            if (_products == null)
            {
                _products = new List<Product>(); 
            }
        }

        public void SaveData()
        {
            var json = JsonConvert.SerializeObject(_products);
            File.WriteAllText(_filePath, json);
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
