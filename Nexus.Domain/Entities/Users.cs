using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Domain.Entities
{
    public class Users
    {
        public Guid UsersId { get; private set; }
        public string Full_Name { get; private set; }
        public string Username { get; private set; }
        public string HashPassword { get; private set; }
        public string Role { get; private set; }
        public bool isActive { get; private set; }

        protected Users() { }

        public Users(string fullname, string username, string hashedPassword, string role)
        {
            Full_Name = fullname;
            Username = username;
            HashPassword = hashedPassword;
            Role = role;
            isActive = true;
        }

        public void DeleteUser()
        {
            isActive = false;
        }
    }
}
