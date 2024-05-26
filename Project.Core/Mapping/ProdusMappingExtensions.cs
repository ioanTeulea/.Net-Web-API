using Project.Database.Dtos.Common;
using Project.Database.Dtos.Request;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Mapping
{
    public static class ProdusMappingExtensions
    {
        public static Produs ToEntity(this AddProdusRequest request)
        {
            if (request == null) return null;

            return new Produs
            {
                Nume = request.Nume,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
        }
        public static ProdusDto ToProdusDto(this Produs entity)
        {
            if (entity == null) return null;

            var result = new ProdusDto();
            result.Id = entity.Id;
            result.Nume = entity.Nume;

            // Convert reviews if needed
            // result.Reviews = entity.Reviews?.Select(r => r.ToReviewDto()).ToList();

            return result;
        }
        public static List<ProdusDto> ToProdusDtos(this List<Produs> entities)
        {
            var results = entities.Select(e => e.ToProdusDto()).ToList();

            return results;
        }
    }
}
