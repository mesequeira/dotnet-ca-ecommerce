using Domain.Entities.Categories;

namespace Domain.Repositories.Categories;

public interface ICategoriesRepository
{
    Task<List<Category>> GetAll();
}
