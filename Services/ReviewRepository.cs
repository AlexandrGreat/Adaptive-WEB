using LR6.Interfaces;
using LR6.Models;

namespace LR6.Services
{
    public class ReviewRepository : IReviewRepository
    {
        public async Task<Review[]> GetAllReviews()
        {
            return reviewList.ToArray();
        }

        public async Task<Review> GetReview(int id)
        {
            return reviewList[id - 1];
        }

        public async Task<Review[]> PutReview(Review review, int id)
        {
            reviewList[id - 1] = review;
            return reviewList.ToArray();
        }

        public async Task<Review[]> AddReview(Review review)
        {
            reviewList.Add(review);
            return reviewList.ToArray();
        }

        public async Task<Review[]> DeleteReview(int id)
        {
            reviewList.RemoveAt(id - 1);
            return reviewList.ToArray();
        }

        private static Review[] data = {
            new Review { UserName="Alex",ProductName="Product1",IsPositive=true,ReviewBody="Nice Product. Recomending!"},
            new Review { UserName="Mike",ProductName="Product2",IsPositive=false,ReviewBody="Bad Product. Not recomending!"},
            new Review { UserName="Jake",ProductName="Product3",IsPositive=true,ReviewBody="Nice Product. Recomending!"},
            new Review { UserName="Alex",ProductName="Product4",IsPositive=true,ReviewBody="Nice Product. Recomending!"},
            new Review { UserName="Jane",ProductName="Product5",IsPositive=true,ReviewBody="Nice Product. Recomending!"},
            new Review { UserName="Elizabeth",ProductName="Product6",IsPositive=false,ReviewBody="Bad Product. Not recomending!"},
            new Review { UserName="Tim",ProductName="Product7",IsPositive=false,ReviewBody="Bad Product. Not recomending!"},
            new Review { UserName="Alex",ProductName="Product8",IsPositive=true,ReviewBody="Nice Product. Recomending!"},
            new Review { UserName="Mike",ProductName="Product9",IsPositive=false,ReviewBody="Bad Product. Not recomending!"},
            new Review { UserName="Alex",ProductName="Product10",IsPositive=true,ReviewBody="Nice Product. Recomending!"},
        };
        public List<Review> reviewList = new List<Review>(data);
    }
}
