using LR6.Interfaces;
using LR6.Models;

namespace LR6.Services
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product[]> GetAllProducts()
        {
            return productList.ToArray();
        }

        public async Task<Product> GetProduct(int id)
        {
            return productList[id - 1];
        }

        public async Task<Product[]> PutProduct(Product product, int id)
        {
            productList[id - 1] = product;
            return productList.ToArray();
        }

        public async Task<Product[]> AddProduct(Product product)
        {
            productList.Add(product);
            return productList.ToArray();
        }

        public async Task<Product[]> DeleteProduct(int id)
        {
            productList.RemoveAt(id - 1);
            return productList.ToArray();
        }

        private static Product[] data = {
            new Product{ Name="Product1",Publisher="Publisher1",Rating=4.1,Downloads=111111},
            new Product{ Name="Product2",Publisher="Publisher2",Rating=4.2,Downloads=222222},
            new Product{ Name="Product3",Publisher="Publisher3",Rating=4.3,Downloads=333333},
            new Product{ Name="Product4",Publisher="Publisher4",Rating=4.4,Downloads=444444},
            new Product{ Name="Product5",Publisher="Publisher5",Rating=4.5,Downloads=555555},
            new Product{ Name="Product6",Publisher="Publisher6",Rating=4.6,Downloads=666666},
            new Product{ Name="Product7",Publisher="Publisher7",Rating=4.7,Downloads=777777},
            new Product{ Name="Product8",Publisher="Publisher8",Rating=4.8,Downloads=888888},
            new Product{ Name="Product9",Publisher="Publisher9",Rating=4.9,Downloads=999999},
            new Product{ Name="Product10",Publisher="Publisher10",Rating=5.0,Downloads=1000000},
        };
        public List<Product> productList = new List<Product>(data);
    }
}
