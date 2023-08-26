namespace Domain.Dtos.Products.Discounts;

public sealed class DiscountDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double DiscountPercent { get; set; }
    public bool Active { get; set; }
}
