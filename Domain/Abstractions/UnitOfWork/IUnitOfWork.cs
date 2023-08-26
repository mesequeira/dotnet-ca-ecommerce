﻿namespace Domain.Abstractions.UnitOfWork;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}
