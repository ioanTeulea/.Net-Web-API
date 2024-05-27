using Microsoft.AspNetCore.Identity.Data;
using Project.Database.Entities;
using Project.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Database.Dtos.Request;

namespace Project.Core.Servicies
{
    public class UsersService
    {
        public AuthService authService { get; set; }
        public UsersRepository usersRepository { get; set; }
        public UsersService(
            AuthService authService,
            UsersRepository usersRepository)
        {
            this.authService = authService;
            this.usersRepository = usersRepository;
        }

        public void Register(Database.Dtos.Request.RegisterRequest registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var salt = authService.GenerateSalt();
            var hashedPassword = authService.HashPassword(registerData.Password, salt);

            var user = new User();
            user.FirstName = registerData.FirstName;
            user.LastName = registerData.LastName;
            user.Email = registerData.Email;
            user.Password = hashedPassword;
            var role = usersRepository.GetRoleByUserRole(registerData.Role);
            if (role != null)
            {
                user.UserRole = role;
            }
            user.PasswordSalt = Convert.ToBase64String(salt);
            user.DateCreated = DateTime.UtcNow;
            usersRepository.Add(user);
        }

        public string Login(Database.Dtos.Request.LoginRequest payload)
        {
            var user = usersRepository.GetByEmail(payload.Email);

            if (authService.HashPassword(payload.Password, Convert.FromBase64String(user.PasswordSalt)) == user.Password)
            {
                var role = usersRepository.GetRoleById(user.RoleId).UserRole;

                return authService.GetToken(user, role);
            }
            else
            {
                return null;
            }
        }
       
    }
}
