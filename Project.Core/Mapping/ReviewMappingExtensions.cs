using Project.Database.Dtos.Request;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Mapping
{
    public static class ReviewMappingExtensions
    {
        public static Review ToEntity(this AddReviewRequest request)
        {
            if (request == null) return null;

            return new Review
            {
                Titlu = request.Titlu,
                Descriere = request.Descriere,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
        }
    }
}
