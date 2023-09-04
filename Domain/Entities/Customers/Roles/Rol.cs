using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Customers.Roles;

[Table("Roles")]
public sealed class Rol : BaseAuditableEntity
{
    [Required]
    [MinLength(1, ErrorMessage = $"Name need be longer than 1 characters.")]
    [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
    public string Name { get; set; }
}
