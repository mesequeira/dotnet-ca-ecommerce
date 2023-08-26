using Domain.Abstractions.UnitOfWork;
using Domain.Repositories.Customers;
using Domain.Repositories.Products;
using Infrastructure.Repositories.Customers;
using Infrastructure.Repositories.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class InterfaceDependency
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
