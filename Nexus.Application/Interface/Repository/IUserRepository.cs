using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexus.Domain.Entities;

namespace Nexus.Application.Interface.Repository
{
    public interface IUserRepository
    {
        Task CreateUserAsync(Users user);
    }
}
