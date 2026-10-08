using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.DTO
{
    public class UserResponseDTO
    {
        public Guid UserId { get; set; }
        public string Full_Name { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}
