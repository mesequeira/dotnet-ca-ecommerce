using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Products.Inventories;

public class Inventory : BaseAuditableEntity
{
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
    public int Quantity { get; set; }
}
