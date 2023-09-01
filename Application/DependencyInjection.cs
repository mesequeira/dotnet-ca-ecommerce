using Application.Abstractions.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>());

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>)
        );

        services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>(includeInternalTypes: true);
        

        services.AddAutoMapper(ApplicationAssemblyReference.Assembly);

        return services;
    }
}
