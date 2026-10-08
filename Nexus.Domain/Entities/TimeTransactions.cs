using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Domain.Entities
{
    public class TimeTransactions
    {
        public Guid TimeTransactionsId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customers Customers { get; private set; }
        public int Seconds { get; private set; }
        public string Type { get; private set; } //Purchase, AddTime, Return, Adjustment
        public DateTime CreateAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? Remarks { get; private set; }

        protected TimeTransactions() { }

        public TimeTransactions(Guid customerId, int seconds, string type, string? remarks)
        {
            TimeTransactionsId = Guid.NewGuid();
            CustomerId = customerId;
            Seconds = seconds;
            Type = type;
            CreateAt = DateTime.UtcNow;
            Remarks = remarks;
        }
        
    }
}
