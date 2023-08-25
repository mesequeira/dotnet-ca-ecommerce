using Domain.Entities.Products;

namespace Domain.Repositories.Products;
public interface IProductRepository
{
    Task<bool> AddAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(Product product);
    Task<Product> GetByIdAsync(long id);
    Task<List<Product>> GetAllAsync();
}
