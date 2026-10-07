using Microsoft.EntityFrameworkCore;
using Nexus.Application.Interface.Repository;
using Nexus.Domain.Entities;
using Nexus.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _context;

        public CustomerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateCustomerAsync(Customers customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task<IEnumerable<Customers>> GetAllActiveCustomersAsync()
        {
            return await _context.Customers.Where(x => x.isActive).ToListAsync();
        }

        public async Task<IEnumerable<Customers>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
