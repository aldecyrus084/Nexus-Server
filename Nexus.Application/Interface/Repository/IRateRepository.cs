using Nexus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Interface.Repository
{
    public interface IRateRepository
    {
        Task CreateRateAsync(Rates rate);
        Task<IEnumerable<Rates>> GetRatesByStatusAsync(bool isVip);
    }
}
