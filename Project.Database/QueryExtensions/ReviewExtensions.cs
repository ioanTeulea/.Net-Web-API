using Project.Database.Dtos.Common;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.QueryExtensions
{
    public static class ReviewExtensions
    {
        public static List<ReviewDto> ToReviewDtos(this IEnumerable<Review> reviews)
        {
            var reviewDtos = new List<ReviewDto>();

            foreach (var review in reviews)
            {
                var reviewDto = new ReviewDto
                {
                    Id = review.Id,
                    Titlu=review.Titlu,
                    Descriere=review.Descriere,
                };

                reviewDtos.Add(reviewDto);
            }

            return reviewDtos;
        }
    }
}
