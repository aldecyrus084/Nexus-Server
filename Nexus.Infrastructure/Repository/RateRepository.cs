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
    public class RateRepository : IRateRepository
    {
        private readonly ApplicationDBContext _context;
        public RateRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task CreateRateAsync(Rates rate)
        {
            await _context.Rates.AddAsync(rate);
        }

        public async Task<IEnumerable<Rates>> GetAllNonVipRates()
        {
            return await _context.Rates.Where(x => !x.IsVip).ToListAsync();
        }

        public async Task<IEnumerable<Rates>> GetAllVipRates()
        {
            return await _context.Rates.Where(x => x.IsVip).ToListAsync();
        }
    }
}
