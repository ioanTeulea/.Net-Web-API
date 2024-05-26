using Project.Database.Dtos.Request;
using Project.Database.Entities;
using Project.Database.Repositories;
using System.Collections.Generic;
using Project.Core.Mapping;
using Project.Database.Dtos.Response;
using Project.Database.QueryExtensions;

namespace Project.Core.Services
{
    public class ReviewService
    {
        private readonly ReviewRepository _reviewRepository;

        public ReviewService(ReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public GetReviewsResponse GetReviewsByProdusId(int produsId)
        {
            var reviews = _reviewRepository.GetReviewsByProdusId(produsId);

            var response = new GetReviewsResponse();
            response.Reviews = reviews.ToReviewDtos();
            response.Count = reviews.Count();

            return response;
        }

        public void AddReview(AddReviewRequest request)
        {
            var review = request.ToEntity();
            _reviewRepository.AddReview(review);
        }
        public void UpdateReview(int id,UpdateReviewRequest request)
        {
            var existingReview = _reviewRepository.GetReviewById(id);
            if (existingReview == null)
            {
                // Handle the error or throw an exception
                return;
            }

            _reviewRepository.UpdateReview(existingReview, request);
        }

        public void DeleteReview(DeleteReviewRequest request)
        {
            _reviewRepository.DeleteReview(request.Id);
        }

    }
}
