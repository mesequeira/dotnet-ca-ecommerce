using Domain.Entities.Customers.Roles;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Customers;

public class Customer : BaseAuditableEntity
{
    [Required]
    public string Password { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = $"Name need be longer than 1 characters.")]
    [MaxLength(150, ErrorMessage = "Name cannot be longer than 150 characters.")]
    public string Name { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = $"LastName need be longer than 1 characters.")]
    [MaxLength(150, ErrorMessage = "LastName cannot be longer than 150 characters.")]
    public string LastName { get; set; }
    [Required]
    [MinLength(1, ErrorMessage = $"City need be longer than 1 characters.")]
    [MaxLength(200, ErrorMessage = "City cannot be longer than 200 characters.")]
    public string City { get; set; }
    [Required]
    public string PostalCode { get; set; }
    [Required]
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string AditionalInformation { get; set; }
    [Required]
    public DateTime Birthday { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public long RolId { get; set; }

    public virtual Rol Rol { get; set; }
}
