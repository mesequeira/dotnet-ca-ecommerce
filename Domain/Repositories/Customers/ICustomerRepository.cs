using Domain.Entities.Customers;

namespace Domain.Repositories.Customers;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);

    Task<Customer> GetByEmailAsync(string email);
}
