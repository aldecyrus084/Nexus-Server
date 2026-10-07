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
    public class CustomerTimeConfiguration : IEntityTypeConfiguration<CustomerTime>
    {
        public void Configure(EntityTypeBuilder<CustomerTime> builder)
        {
            builder.HasKey(x => x.CustomerTimeId);
        }
    }
}
