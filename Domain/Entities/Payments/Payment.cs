using Domain.Entities.Orders;

namespace Domain.Entities.Payments;

public class Payment : BaseAuditableEntity
{
    public long OrderId { get; set; }
    public double Amount { get; set; }
    public bool Status { get; set; }
    public string Provider { get; set; }
    public string Description { get; set; }
    public virtual Order Order { get; set; }
}