using Nexus.Application.Interface.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public  UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task BeginTransactionAsync(CancellationToken cToken = default)
        {
            await _context.Database.BeginTransactionAsync(cToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cToken = default)
        {
            var transaction = _context.Database.CurrentTransaction;
            if(transaction != null)
            {
                await _context.Database.CommitTransactionAsync(cToken);
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cToken = default)
        {
            var transaction = _context.Database.CurrentTransaction;
            if(transaction != null)
            {
                await _context.Database.RollbackTransactionAsync(cToken);
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cToken = default)
        {
            return await _context.SaveChangesAsync(cToken);
        }
    }
}
