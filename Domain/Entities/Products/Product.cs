using Domain.Entities.Categories;
using Domain.Entities.Products.Discounts;
using Domain.Entities.Products.Inventories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Products;

public class Product : BaseAuditableEntity
{
    [Required]
    [MinLength(5, ErrorMessage = $"Name need be longer than 5 characters.")]
    [MaxLength(500, ErrorMessage = "Name cannot be longer than 500 characters.")]
    public string Name { get; set; }
    
    [MinLength(25, ErrorMessage = "Description need be longer than 25 characters.")]
    [MaxLength(4000, ErrorMessage = "Description cannot be longer than 4000 characters.")]
    public string Description { get; set; }

    [Required]
    public string Sku { get; set; }

    [Required]
    public bool Status { get; set; }

    [Required]
    [Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
    public double Price { get; set; }

    [ForeignKey(nameof(Category))]
    public long? CategoryId { get; set; }

    [ForeignKey(nameof(Discount))]
    public long? DiscountId { get; set; }
    
    [ForeignKey(nameof(Inventory))]
    public long InventoryId { get; set; }


    public virtual Category Category { get; set; }
    public virtual Discount Discount { get; set; }
    public virtual Inventory Inventory { get; set; }
}
