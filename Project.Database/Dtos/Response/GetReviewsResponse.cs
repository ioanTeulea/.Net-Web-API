using Project.Database.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Dtos.Response
{
    public class GetReviewsResponse
    {
        public List<ReviewDto> Reviews { get; set; }
        public int Count { get; set; }
    }
}
