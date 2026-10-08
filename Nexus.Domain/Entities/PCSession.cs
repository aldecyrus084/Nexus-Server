using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Domain.Entities
{
    public class PCSession
    {
        public Guid SessionId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid PCId { get; private set; }
        // Add the PC table here for navigation
        public DateTime StartedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public DateTime? EndedAt { get; private set; }
        public string Status { get; private set; }

        protected PCSession() { }

        public PCSession(Guid customerId, Guid pcId, int allocatedTime)
        {
            CustomerId = customerId;
            PCId = pcId;
            StartedAt = DateTime.Now;
            ExpiresAt = StartedAt.AddSeconds(allocatedTime);
            Status = "Active";

        }
    }
}
