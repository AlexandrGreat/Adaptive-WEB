using LR6.Models;

namespace LR6.Interfaces
{
    public interface IReviewRepository
    {
        public Task<Review[]> GetAllReviews();
        public Task<Review> GetReview(int id);
        public Task<Review[]> PutReview(Review review, int id);
        public Task<Review[]> DeleteReview(int id);
        public Task<Review[]> AddReview(Review review);
    }
}
