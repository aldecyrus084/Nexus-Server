using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Infrastructure.Persistence.Configuration
{
    public class PointTransactionConfiguration : IEntityTypeConfiguration<PointTransactions>
    {
        public void Configure(EntityTypeBuilder<PointTransactions> builder)
        {
            builder.HasKey(x => x.PointTransactionId);

            builder.HasOne(x => x.Customers)
                .WithMany(x => x.PointTransactions)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
