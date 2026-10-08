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
    public class PCSessionRepository : IPcSessionRepository
    {
        private readonly ApplicationDBContext _context;

        public PCSessionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreatePcSessionAsync(PCSession pcSession)
        {
            await _context.PCSession.AddAsync(pcSession);
        }
    }
}
