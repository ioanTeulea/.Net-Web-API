using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Dtos.Request
{
    public class AddReviewRequest
    {
        public int ProdusId { get; set; } // Id-ul review-ului care va fi actualizat
        public string Titlu { get; set; }
        public string Descriere { get; set; }
        public int Nota { get; set; }

    }
}
