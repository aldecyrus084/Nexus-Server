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
    public class PointTransactionRepository : IPointTransactionRepository
    {
        private readonly ApplicationDBContext _context;

        public PointTransactionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreatePointAsync(PointTransactions pointTransaction)
        {
            await _context.PointTransactions.AddAsync(pointTransaction);
        }
    }
}
