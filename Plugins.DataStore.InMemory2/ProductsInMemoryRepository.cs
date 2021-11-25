using System;
using System.Collections.Generic;
using System.Linq;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory2
{
    public class ProductsInMemoryRepository : IProductRepository
    {

        private List<Product> products;

        public ProductsInMemoryRepository()
        {
            products = new List<Product>()
            {
                new Product{ ProductId = 1, CategoryId = 1, Name = "Chá Gelado", Quantity = 100, Price = 1.99},
                new Product{ ProductId = 2, CategoryId = 1, Name = "Cerveja", Quantity = 200, Price = 3.99},
                new Product{ ProductId = 3, CategoryId = 2, Name = "Pao Integral", Quantity = 200, Price = 1.50},
                new Product{ ProductId = 4, CategoryId = 2, Name = "Pao Frances", Quantity = 200, Price = 1},
            };

        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            var maxId = products.Any() ? products.Max(x => x.ProductId) : 0;
            product.ProductId = maxId + 1;


            products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public Product GetProductById(int productId)
        {
            return products.Find(x => x.ProductId == productId);
        }

        public void UpdateProduct(Product product)
        {
            //categories?.FirstOrDefault(x => x.CategoryId == category.CategoryId)
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.CategoryId = product.CategoryId;

            }
        }
    }
}
