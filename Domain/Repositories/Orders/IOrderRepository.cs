using Domain.Entities.Orders;

namespace Domain.Repositories.Orders;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    void UpdateAsync(Order order);
    Task<Order> GetByIdAsync(long id);
    Task<List<Order>> GetAllAsync();
}