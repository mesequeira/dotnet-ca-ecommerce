using Domain.Entities.Categories;

namespace Domain.Entities.Products;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual Category Category { get; set; }
}
