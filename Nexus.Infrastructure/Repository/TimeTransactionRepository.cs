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
    public class TimeTransactionRepository : ITimeTransactionRepository
    {
        private ApplicationDBContext _context;
        public TimeTransactionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateTimeTransactionAsync(TimeTransactions timeTransaction)
        {
            await _context.TimeTransactions.AddAsync(timeTransaction);
        }
    }
}
