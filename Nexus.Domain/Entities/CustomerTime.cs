using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Domain.Entities
{
    public class CustomerTime
    {
        public Guid CustomerTimeId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customers Customer { get; private set; }
        public int AvailableSeconds { get; private set; }
    }
}
