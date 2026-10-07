using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Domain.Entities
{
    public class PointTransactions
    {
        public Guid PointTransactionId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customers Customers { get; private set; }
        public int Points { get; private set; }
        public string Type { get; private set; } // Earn, Redeem, Adjustment
        public string? Reference { get; private set; }
        public string? Remarks { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected PointTransactions() { }
        
        public PointTransactions(Guid customerId, int point, string type, string? reference, string? remarks)
        {
            CustomerId = customerId;
            Points = point;
            Type = type;
            Reference = reference;
            Remarks = remarks;
            CreatedAt = DateTime.UtcNow;
        }

        public void Adjustment(int point)
        {
            Points = point;
            Type = "Adjustment";
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
