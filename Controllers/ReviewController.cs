using LR6.Interfaces;
using LR6.Models;
using LR6.Services;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers
{
    [ApiController]
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

        [HttpGet("GetReviews")]
        public Task<Review[]> GetReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        [HttpGet("GetReview")]
        public Task<Review> GetReview(int id)
        {
            return _reviewRepository.GetReview(id);
        }

        [HttpPost("AddReview")]
        public Task<Review[]> AddReview(Review review)
        {
            return _reviewRepository.AddReview(review);
        }

        [HttpPut("PutReview")]
        public Task<Review[]> PutReview(Review review, int id)
        {
            return _reviewRepository.PutReview(review, id);
        }

        [HttpDelete("DeleteReview")]
        public Task<Review[]> DeleteReview(int id)
        {
            return _reviewRepository.DeleteReview(id);
        }
    }
}
