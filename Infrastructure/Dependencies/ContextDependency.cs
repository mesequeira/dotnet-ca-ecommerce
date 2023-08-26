using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dependencies;

public static class ContextDependency
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
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

        return services;
    }
}
