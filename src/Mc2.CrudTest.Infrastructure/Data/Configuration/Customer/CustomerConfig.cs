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
            builder.Property(c => c.DateOfBirth).HasColumnType("datetime2");

            builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique();

            builder.OwnsOne(customer => customer.Email, ownedNav =>
            {
                ownedNav
                    .Property(email => email.Address)
                    .IsRequired() // NOT NULL
                    .HasColumnType("NVARCHAR(100)")
                    .HasColumnName(nameof(Domain.Aggregates.Customer.Customer.Email));

                // Unique Index
                ownedNav
                    .HasIndex(email => email.Address)
                    .IsUnique();
            });

            builder.OwnsOne(customer => customer.BankAccountNumber, ownedNav =>
            {
                ownedNav
                    .Property(c => c.Number)
                    .IsRequired().HasColumnType("VARCHAR(35)")
                    .HasColumnName(nameof(Domain.Aggregates.Customer.Customer.BankAccountNumber));
            });
        }
    }
}
