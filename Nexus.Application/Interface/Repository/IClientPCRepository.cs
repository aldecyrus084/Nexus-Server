using Nexus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Interface.Repository
{
    public interface IClientPCRepository
    {
        Task RegisterClientPCAsync(ClientPC client);

        Task<ClientPC?> getClientPCByIdAsync(Guid Id);
    }
}
