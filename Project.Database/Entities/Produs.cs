﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Entities
{
    public class Produs : BaseEntity
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public decimal Pret { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
