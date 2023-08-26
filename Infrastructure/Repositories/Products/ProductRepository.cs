using Domain.Entities.Products;
using Domain.Repositories.Products;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Products;

internal sealed class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product) =>
        await _context.Products.AddAsync(product);

    public void UpdateAsync(Product product) =>
        _context.Products.Update(product);

    public async Task DeleteAsync(Product product) =>
        await _context.Products
                        .Where(prod => prod.Id == product.Id)
                        .ExecuteDeleteAsync();

    public async Task<List<Product>> GetAllAsync() =>
        await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .Include(p => p.Discount)
                .ToListAsync();
    public async Task<Product?> GetByIdAsync(long id) =>
        await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .Include(p => p.Discount)
                .FirstAsync(prod => prod.Id == id);

    public async Task<bool> IsSkuUniqueAsync(string sku) =>
        !await _context.Products.AnyAsync(p => p.Sku == sku);
}
