using Domain.Entities.Products;

namespace Domain.Entities.Orders.Items;

public class OrderItem : BaseAuditableEntity
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }

    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
}
