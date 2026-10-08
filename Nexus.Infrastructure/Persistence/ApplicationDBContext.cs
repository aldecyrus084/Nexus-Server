using Microsoft.EntityFrameworkCore;
using Nexus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext  
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerTime> CustomerTime { get; set; }
        public DbSet<PointTransactions> PointTransactions { get; set; }
        public DbSet<TimeTransactions> TimeTransactions { get; set; }
        public DbSet<PCSession> PCSession { get; set; }
        public DbSet<Rates> Rates { get; set; }
        public DbSet<ClientPC> ClientPC { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }
    }
}
