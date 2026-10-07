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
    public class CustomerTimeRepository : ICustomerTimeRepository
    {
        private readonly ApplicationDBContext _context;

        public CustomerTimeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateCustomerTimeAsync(CustomerTime customerTime)
        {
            await _context.CustomerTime.AddAsync(customerTime);
        }
    }
}
