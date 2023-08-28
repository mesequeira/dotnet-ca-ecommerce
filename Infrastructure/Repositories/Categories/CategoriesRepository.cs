using Domain.Entities.Categories;
using Domain.Repositories.Categories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Categories;

internal sealed class CategoriesRepository : ICategoriesRepository
{
    private readonly ApplicationDbContext _context;

    public CategoriesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAll() =>
        await _context.Categories.ToListAsync();
}
