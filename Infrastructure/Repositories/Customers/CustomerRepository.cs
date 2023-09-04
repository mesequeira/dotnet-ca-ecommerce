using Domain.Entities.Customers;
using Domain.Repositories.Customers;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Customer?> GetByEmailAsync(string email) =>
        await _context
                    .Customers
                    .Include(m => m.Rol)
                    .FirstOrDefaultAsync(m => m.Email == email);
}
