using Domain.Repositories.Products;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
        services.AddDbContext<ApplicationDbContext>(
            (sp, optionsBuilder) =>
            {
                var auditableInterceptor = sp.GetService<UpdateAuditableEntitiesInterceptor>()!;
                optionsBuilder.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    builder =>
                        builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .AddInterceptors(auditableInterceptor);
            }
        );

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
