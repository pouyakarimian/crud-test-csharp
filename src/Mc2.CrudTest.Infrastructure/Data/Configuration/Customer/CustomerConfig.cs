using Mc2.CrudTest.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.Data.Configuration.Customer
{
    public class CustomerConfig : IEntityTypeConfiguration<Domain.Aggregates.Customer.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.Customer.Customer> builder)
        {
            builder.ConfigureBaseEntity();
            builder.Property(c => c.FirstName).HasColumnType("VARCHAR(100)");
            builder.Property(c => c.LastName).HasColumnType("VARCHAR(100)");
            builder.Property(c => c.PhoneNumber).HasColumnType("VARCHAR(25)");
            builder.Property(c => c.BankAccountNumber).IsRequired().HasColumnType("VARCHAR(35)");
            builder.Property(c => c.Email).IsRequired().HasColumnType("NVARCHAR(100)");
            builder.Property(c => c.DateOfBirth).HasColumnType("datetime2");
            builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique();
            builder.HasIndex(c => c.Email).IsUnique();
        }
    }
}
