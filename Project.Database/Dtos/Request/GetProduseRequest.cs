using Project.Database.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Dtos.Request
{
    public class GetProduseRequest
    {
        public SortingCriterionDto SortingCriterion { get; set; }

        public string Nume { get; set; }

        public decimal? Pret { get; set; }
    }
}
