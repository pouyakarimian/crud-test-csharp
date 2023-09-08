using Mc2.CrudTest.Domain.Aggregates.Customer;
using Mc2.CrudTest.Infrastructure.Data.Configuration.Customer;
using Mc2.CrudTest.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data.Context
{
    public class CrudTestDbContext : DbContext
    {
        private const string Collation = "Latin1_General_CI_AI";

        protected CrudTestDbContext(DbContextOptions<CrudTestDbContext> dbOptions) : base(dbOptions)
        {
        }
        public DbSet<Customer> Customers => Set<Customer>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation(Collation).RemoveCascadeDeleteConvention();
            modelBuilder.ApplyConfiguration(new CustomerConfig());
        }
    }
}
