using Domain.Dtos.Products.Categories;
using Domain.Dtos.Products.Discounts;
using Domain.Dtos.Products.Inventories;

namespace Domain.Dtos.Products;

public sealed class ProductDto
{
    public long ProductId { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public string Sku { get; set; }

    public bool Status { get; set; }

    public double Price { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }

    public long? CategoryId { get; set; }

    public long? DiscountId { get; set; }
    public long InventoryId { get; set; }

    public InventoryDto Inventory { get; set; }
    public DiscountDto Discount { get; set; }
    public CategoryDto Category { get; set; }
}
