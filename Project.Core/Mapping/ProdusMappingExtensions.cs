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
    }
}
