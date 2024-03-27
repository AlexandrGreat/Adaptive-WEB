using Microsoft.AspNetCore.Mvc;
using LR6.Models;
using LR6.Services;
using LR6.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LR6.Controllers
{
    [Authorize]
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

        [HttpGet]
        public Task<Product[]> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Task<Product> GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        [HttpPost]
        public Task<Product[]> AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        [HttpPut("{id}")]
        public Task<Product[]> PutProduct(Product product, int id)
        {
            return _productRepository.PutProduct(product, id);
        }

        [HttpDelete("{id}")]
        public Task<Product[]> DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
    }
}