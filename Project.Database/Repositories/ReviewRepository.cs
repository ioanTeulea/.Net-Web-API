using Project.Database.Context;
using Project.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Project.Database.Dtos.Request;

namespace Project.Database.Repositories
{
    public class ReviewRepository
    {
        private readonly ProjectDbContext _context;

        public ReviewRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetReviewsByProdusId(int produsId)
        {
            return _context.Reviews.Where(r => r.IdProdus == produsId).ToList();
        }
        public Review GetReviewById(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == id && r.DateDeleted == null);
        }


        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void UpdateReview(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }
        public static Review ToEntity(UpdateReviewRequest request)
        {
            return new Review
            {
                Id = request.Id,
                Titlu = request.Titlu,
                Descriere = request.Descriere,
                DateUpdated = DateTime.UtcNow
            };
        }
    }
}
