using Project.Database.Dtos.Request;
using Project.Database.Entities;
using Project.Database.Repositories;
using System.Collections.Generic;
using Project.Core.Mapping;

namespace Project.Core.Services
{
    public class ReviewService
    {
        private readonly ReviewRepository _reviewRepository;

        public ReviewService(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<Review> GetReviewsByProdusId(int produsId)
        {
            return _reviewRepository.GetReviewsByProdusId(produsId);
        }

        public void AddReview(AddReviewRequest request)
        {
            var review = request.ToEntity();
            _reviewRepository.AddReview(review);
        }
        public void UpdateReview(UpdateReviewRequest request)
        {
            var existingReview = _reviewRepository.GetReviewById(request.Id);
            if (existingReview == null)
            {
                // Handle the error or throw an exception
                return;
            }

            var updatedReview = ReviewRepository.ToEntity(request);
            _reviewRepository.UpdateReview(updatedReview);
        }

        public void DeleteReview(DeleteReviewRequest request)
        {
            _reviewRepository.DeleteReview(request.Id);
        }

    }
}
