namespace Domain.Entities.Products.Discounts;

public class Discount : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double DiscountPercent { get; set; }
    public bool Active { get; set; }
}
