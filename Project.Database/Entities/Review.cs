using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Entities
{
    public class Review : BaseEntity
    {
        public int Id { get; set; }
        public int IdProdus { get; set; } 
        public string Titlu { get; set; }
        public string Descriere { get; set; }
        public int Nota { get; set; } 

        public Produs Produs { get; set; } 
    }
}
