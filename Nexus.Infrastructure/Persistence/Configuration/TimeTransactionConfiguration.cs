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
    public class TimeTransactionConfiguration : IEntityTypeConfiguration<TimeTransactions>
    {
        public void Configure(EntityTypeBuilder<TimeTransactions> builder)
        {
            builder.HasKey(x => x.TimeTransactionsId);

            builder.HasOne(x => x.Customers)
                .WithMany(x => x.TimeTransactions)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
