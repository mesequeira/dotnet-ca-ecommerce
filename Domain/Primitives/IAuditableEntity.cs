namespace Domain.Primitives;

public interface IAuditableEntity
{
    public long Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }
}
