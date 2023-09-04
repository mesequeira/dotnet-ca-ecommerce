using Domain.Entities.Customers.Roles;
using Domain.Repositories.Roles;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Roles;

internal sealed class RolesRepository : IRolesRepository
{
    private readonly ApplicationDbContext _context;

    public RolesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Rol rol) => 
        await _context.Roles
                .AddAsync(rol);

    public async Task DeleteAsync(Rol rol) =>
        await _context.Roles
                .Where(r => r.Id == rol.Id)
                .ExecuteDeleteAsync();


    public async Task<List<Rol>> GetAllAsync() =>
        await _context.Roles
                .ToListAsync();

    public async Task<Rol?> GetByNameAsync(string name) =>
        await _context.Roles
                .FirstOrDefaultAsync(prod => prod.Name == name);

    public void UpdateAsync(Rol rol) =>
        _context.Roles.Update(rol);
}
