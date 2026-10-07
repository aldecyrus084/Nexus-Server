using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Domain.Entities
{
    public class Customers
    {
        public Guid CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string HashPassword { get; private set; }
        public bool isActive { get; private set; }
        public string? IpAddress { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected Customers() { }

        public ICollection<PointTransactions> PointTransactions { get; private set; } = new List<PointTransactions>();
        public ICollection<TimeTransactions> TimeTransactions { get; private set; } = new List<TimeTransactions>();

        public Customers(string name, string username, string hashedPassword, decimal points)
        {
            CustomerId = Guid.NewGuid();
            Name = name;
            Username = username;
            HashPassword = hashedPassword;
            isActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void DeleteCustomer()
        {
            isActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Login(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public void Logout()
        {
            IpAddress = "";
        }
    }
}
