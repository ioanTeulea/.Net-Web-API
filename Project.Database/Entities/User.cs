using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Entities
{
    public class User:BaseEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }

        public Role UserRole { get; set; }

        // Lista de recenzii, doar pentru utilizatorii obișnuiți
        public List<Review> Reviews { get; set; }

        // Lista de produse, doar pentru administratori
        public List<Produs> Products { get; set; }
    }
}
