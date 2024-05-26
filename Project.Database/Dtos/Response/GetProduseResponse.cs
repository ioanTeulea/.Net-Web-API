using Project.Database.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Dtos.Response
{
    public class GetProduseResponse
    {
        public List<ProdusDto> Produse { get; set; }
        public int Count { get; set; }
    }
}
