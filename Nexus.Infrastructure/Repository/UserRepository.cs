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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(Users user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
