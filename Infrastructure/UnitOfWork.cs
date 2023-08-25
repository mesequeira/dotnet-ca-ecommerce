using Domain.Abstractions.UnitOfWork;

namespace Infrastructure;

internal sealed class UnitOfWork : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
