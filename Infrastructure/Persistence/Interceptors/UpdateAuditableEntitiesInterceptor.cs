using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Persistence.Interceptors;

/// <summary>
/// Interceptor that insert the DateTime to auditable attributes of the entites
/// </summary>
public sealed class UpdateAuditableEntitiesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result, 
        CancellationToken cancellationToken = default)
    {
        var dbContext = eventData.Context;

        if(dbContext is null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        var entries = dbContext
                            .ChangeTracker
                            .Entries<IAuditableEntity>();

        foreach(var entityEntry in entries)
        {
            if(entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(a => a.Created).CurrentValue = DateTime.Now;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property(a => a.Modified).CurrentValue = DateTime.Now;
            }
        }
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
