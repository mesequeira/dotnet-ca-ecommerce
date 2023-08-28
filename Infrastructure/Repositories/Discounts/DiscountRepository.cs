using Domain.Entities.Products.Discounts;
using Domain.Repositories.Discounts;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Discounts;

internal sealed class DiscountRepository : IDiscountRepository
{
    private readonly ApplicationDbContext _context;

    public DiscountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Discount>> GetAll() =>
        await _context.Discounts.ToListAsync();
}
