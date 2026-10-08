using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.DTO
{
    public class CustomerResponseDTO
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public bool isActive { get; set; }
        public string? IpAddress { get; set; }
    }
}
