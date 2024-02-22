using Microsoft.AspNetCore.Mvc;
using LR6.Models;
using LR6.Services;
using LR6.Interfaces;

namespace LR6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet("GetProducts")]
        public Task<Product[]> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpGet("GetProduct")]
        public Task<Product> GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        [HttpPost("AddProduct")]
        public Task<Product[]> AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        [HttpPut("PutProduct")]
        public Task<Product[]> PutProduct(Product product, int id)
        {
            return _productRepository.PutProduct(product, id);
        }

        [HttpDelete("DeleteProduct")]
        public Task<Product[]> DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
    }
}