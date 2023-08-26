using Domain.Entities.Customers;
using Domain.Repositories.Customers;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Customers;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Customer customer) =>
        await _context.Customers.AddAsync(customer);

}
