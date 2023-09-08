using Mc2.CrudTest.Domain.Aggregates.Customer;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Infrastructure.Data.Context;
using Mc2.CrudTest.Infrastructure.Data.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data.Repositories;

public class CustomerWriteOnlyRepository : BaseWriteOnlyRepository<Customer, Guid>, ICustomerWriteRepository
{
    public CustomerWriteOnlyRepository(CrudTestDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByEmailAsync(Email email) =>
        await Context.Customers
            .AsNoTracking()
            .AnyAsync(p => p.Email.Address.Equals(email.Address));

    public async Task<bool> ExistsByEmailAsync(Email email, Guid currentId) =>
        await Context.Customers
            .AsNoTracking()
            .AnyAsync(p => p.Email.Address.Equals(email.Address) && p.Id != currentId);
}