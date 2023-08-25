using Domain.Entities.Products;
using Domain.Repositories.Products;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public Task DeleteAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> GetByIdAsync(long id) => 
        await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync();

    public Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
}
