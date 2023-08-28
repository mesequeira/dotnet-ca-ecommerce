using Domain.Abstractions.UnitOfWork;
using Domain.Repositories.Categories;
using Domain.Repositories.Customers;
using Domain.Repositories.Discounts;
using Domain.Repositories.Products;
using Infrastructure.Repositories.Categories;
using Infrastructure.Repositories.Customers;
using Infrastructure.Repositories.Discounts;
using Infrastructure.Repositories.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class InterfaceDependency
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IDiscountRepository, DiscountRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
