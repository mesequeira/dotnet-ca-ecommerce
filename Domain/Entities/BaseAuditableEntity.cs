using Domain.Primitives;

namespace Domain.Entities;

public abstract class BaseAuditableEntity : IAuditableEntity
{
    public long Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }
}
