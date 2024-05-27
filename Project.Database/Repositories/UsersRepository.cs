using Microsoft.EntityFrameworkCore;
using Project.Database.Context;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Repositories
{
    public class UsersRepository : BaseRepository
    {
        public UsersRepository(ProjectDbContext labProjectDbContext) : base(labProjectDbContext)
        {
        }

        public void Add(User user)
        {
            labProjectDbContext.Users.Add(user);
            labProjectDbContext.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            var result = labProjectDbContext.Users

                .Where(e => e.Email == email)
                .Where(e => e.DateDeleted == null)

                .FirstOrDefault();

            return result;
        }
        public Role GetRoleByUserRole(UserRole userRole)
        {
            return labProjectDbContext.Roles.FirstOrDefault(r => r.UserRole == userRole);
        }
        public Role GetRoleById(int roleId)
        {
            return labProjectDbContext.Roles.FirstOrDefault(r => r.Id == roleId);
        }

    }
}
