using Domain.Entities.Customers;

namespace Domain.Entities.Orders.Items;

public class OrderItems : BaseAuditableEntity
{
    public long CustomerId { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public long Quantity { get; set; }

    public virtual Customer Customer { get; set; }
    

}
