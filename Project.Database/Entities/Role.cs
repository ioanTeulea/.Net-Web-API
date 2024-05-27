using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Entities
{
    public enum UserRole
    {
        None,
        User,
        Admin
    }

    public class Role
    {
        public int Id { get; set; }
        public UserRole UserRole { get; set; }

        public List<User> Users { get; set; }
    }
}
