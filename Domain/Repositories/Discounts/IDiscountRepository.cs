using Domain.Entities.Products.Discounts;

namespace Domain.Repositories.Discounts;

public interface IDiscountRepository
{
    Task<List<Discount>> GetAll();
}
