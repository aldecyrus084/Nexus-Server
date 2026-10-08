using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Domain.Entities
{
    public class ClientPC
    {
        public Guid ClientPCId { get; private set; }
        public string IpAddress { get; private set; }
        public bool isVip { get; private set; } = false;

        protected ClientPC() { }

    }
}
