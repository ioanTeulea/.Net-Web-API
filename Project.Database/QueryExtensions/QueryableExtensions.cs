using Project.Database.Dtos.Common;
using Project.Database.Dtos.Response;
using Project.Database.Entities;
using Project.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.QueryExtensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<Produs> Sort(this IQueryable<Produs> query, SortingCriterionDto sortingCriterion)
        {
            if (sortingCriterion == null)
            {
                return query;
            }

            switch (sortingCriterion.Order)
            {
                case SortingOrder.Ascending:
                    {
                        return query.OrderBy(p => p.Pret);
                    }

                case SortingOrder.Descending:
                    {
                        return query.OrderByDescending(p => p.Pret);
                    }

                default:
                    {
                        return query;
                    }
            }
        }
        public static GetProdusResponse ToGetProdusResponse(this Produs produs)
        {
            if (produs == null)
            {
                return null;
            }

            return new GetProdusResponse
            {
                Id = produs.Id,
                Nume = produs.Nume
            };
        }
    }
}
