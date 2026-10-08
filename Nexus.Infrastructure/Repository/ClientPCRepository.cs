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
    public class ClientPCRepository : IClientPCRepository
    {
        private readonly ApplicationDBContext _context;

        public ClientPCRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ClientPC?> getClientPCByIdAsync(Guid Id)
        {
            return await _context.ClientPC.FirstOrDefaultAsync(x => x.ClientPCId == Id);
        }

        public async Task RegisterClientPCAsync(ClientPC client)
        {
            await _context.ClientPC.AddAsync(client);

        }
    }
}
