using Domain.Entities.Customers.Roles;

namespace Domain.Repositories.Roles;

public interface IRolesRepository
{
    Task AddAsync(Rol rol);
    void UpdateAsync(Rol rol);
    Task DeleteAsync(Rol rol);
    Task<Rol> GetByNameAsync(string name);
    Task<List<Rol>> GetAllAsync();
}
