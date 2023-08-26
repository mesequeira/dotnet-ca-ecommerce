namespace Domain.Entities.Customers;

public class Customer : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string IdentityId { get; set; }
}
