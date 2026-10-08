using MediatR;
using Nexus.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Features.User.Create
{
    public class CreateUserCommand : IRequest<GenericResponseDTO<UserResponseDTO>>
    {
        public string Full_Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
