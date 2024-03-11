using LR6.Models;

namespace LR6.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product[]> GetAllProducts();
        public Task<Product> GetProduct(int id);
        public Task<Product[]> PutProduct(Product product, int id);
        public Task<Product[]> DeleteProduct(int id);
        public Task<Product[]> AddProduct(Product product);
    }
}
