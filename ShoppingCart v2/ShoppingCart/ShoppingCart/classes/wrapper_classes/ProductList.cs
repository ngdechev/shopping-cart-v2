using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class ProductList
    {
        private List<Product> products;

        public ProductList()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            product.Id = GenerateUniqueProductId();
            products.Add(product);
        }

        public bool RemoveProduct(int productId)    
        {
            Product product = products.Find(p => p.Id == productId);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }

        public bool EditProduct(int productId, string name, string description, int quantity, decimal price)
        {
            // TODO: 
            return false;
        }

        public void DisplayProductList()
        {
            foreach (Product product in products)
            {
                Console.WriteLine($"Id: {product.Id}\n, Name: {product.Name}\n, Description: {product.Description}\n, Quantity: {product.Quantity}\n, Price: {product.Price}\n");
            }
        }

        public void SearchProducts(string searchTerm)
        {
            List<Product> searchResults = products.FindAll(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
            if (searchResults.Count > 0)
            {
                Console.WriteLine("Search results:");
                foreach (Product product in searchResults)
                {
                    Console.WriteLine($"Id: {product.Id}\n, Name: {product.Name}\n, Description: {product.Description}\n, Quantity: {product.Quantity}\n, Price: {product.Price}\n");
                }
            }
            else
            {
                Console.WriteLine("No products found.");
            }
        }

        private int GenerateUniqueProductId()
        {
            int maxProductId = products.Any() ? products.Max(p => p.Id) : 0;
            return maxProductId + 1;
        }

        public List<Product> LoadFromFile(string filePath)
        {
            // Read the JSON data from the file
            string json = File.ReadAllText(filePath);

            // Deserialize the JSON data to a list of products
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(json);

            return products;
        }

        public void SaveToFile(string filePath)
        {
            // Serialize the list of products to JSON format
            string json = JsonSerializer.Serialize(products);

            // Write the JSON data to the file
            File.WriteAllText(filePath, json);

        }

        public Product GetProductById(int productId)
        {
            Product foundedProduct = null;

            foreach(Product product in products)
            {
                if(product.Id == productId)
                {
                    foundedProduct = product;
                } else
                {
                    Console.WriteLine($"There is no product with id {productId}.");
                }
            }

            return foundedProduct;
        }
    }
}
