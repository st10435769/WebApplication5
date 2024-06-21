using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Services
{
    public class LocalSearchService
    {
        private readonly List<Product> _products;

        public LocalSearchService()
        {
            // Sample data
            _products = new List<Product>
            {
                new Product { ProductID = "1", ProductName = "Handcrafted Ceramic Vase", Description = "A beautiful ceramic vase", Price = 500.00 },
                new Product { ProductID = "2", ProductName = "Handcrafted Wooden Bowl", Description = "A sturdy wooden bowl", Price = 150.00 },
                // Add more sample products as needed
            };
        }

        public List<Product> SearchProducts(string searchText)
        {
            return _products.Where(p => p.ProductName.Contains(searchText) || p.Description.Contains(searchText)).ToList();
        }
    }

    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}