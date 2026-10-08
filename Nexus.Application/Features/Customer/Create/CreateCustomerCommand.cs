using MediatR;
using Nexus.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Features.Customer.Create
{
    public class CreateCustomerCommand : IRequest<GenericResponseDTO<CustomerResponseDTO>>
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? IpAddress { get; set; }
    }
}
