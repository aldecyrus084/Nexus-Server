using Nexus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Interface.Repository
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customers customer);
        Task<IEnumerable<Customers>> GetAllCustomersAsync();
        Task<IEnumerable<Customers>> GetAllActiveCustomersAsync();

    }
}
