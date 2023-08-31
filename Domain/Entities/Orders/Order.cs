using Domain.Entities.Customers;
using Domain.Entities.Orders.Items;
using Domain.Entities.Payments;

namespace Domain.Entities.Orders;

public class Order : BaseAuditableEntity
{
    public long CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
