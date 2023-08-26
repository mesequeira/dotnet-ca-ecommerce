using Domain.Abstractions.UnitOfWork;
using Domain.Repositories.Products;
using Infrastructure.Repositories.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class InterfaceDependency
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
