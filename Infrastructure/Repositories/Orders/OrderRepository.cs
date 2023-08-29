using Domain.Entities.Orders;
using Domain.Repositories.Orders;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Orders;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order) =>
        await _context.Orders.AddAsync(order);

    public void UpdateAsync(Order order) =>
        _context.Orders.Update(order);

    public async Task<List<Order>> GetAllAsync() =>
        await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();

    public async Task<Order?> GetByIdAsync(long id) =>
        await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(ord => ord.Id == id);
}