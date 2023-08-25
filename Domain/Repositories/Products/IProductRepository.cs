using Domain.Entities.Products;

namespace Domain.Repositories.Products;
public interface IProductRepository
{
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
    Task<Product> GetByIdAsync(long id);
    Task<List<Product>> GetAllAsync();
}
