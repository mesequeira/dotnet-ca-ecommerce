namespace Domain.Dtos.Customers;

public sealed class CustomerDto
{
    public string Password { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string AditionalInformation { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    public long RolId { get; set; }
}
