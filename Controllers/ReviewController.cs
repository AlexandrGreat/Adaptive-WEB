using LR6.Interfaces;
using LR6.Models;
using LR6.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewRepository _reviewRepository;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(ILogger<ReviewController> logger, ReviewRepository reviewRepository)
        {
            _logger = logger;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public Task<Review[]> GetReviews()
        {
            return _reviewRepository.GetAllReviews();
        }
        
        [HttpGet("{id}")]
        public Task<Review> GetReview(int id)
        {
            return _reviewRepository.GetReview(id);
        }

        [HttpPost]
        public Task<Review[]> AddReview(Review review)
        {
            return _reviewRepository.AddReview(review);
        }

        [HttpPut("{id}")]
        public Task<Review[]> PutReview(Review review, int id)
        {
            return _reviewRepository.PutReview(review, id);
        }

        [HttpDelete("{id}")]
        public Task<Review[]> DeleteReview(int id)
        {
            return _reviewRepository.DeleteReview(id);
        }
    }
}
