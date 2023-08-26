using Application.Abstractions.Authentication;
using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Dependencies;

public static class AuthenticationDependency
{
    public static IServiceCollection AddAuthenticationFireBase(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var appOptions = new AppOptions()
        {
            Credential = GoogleCredential.FromFile("firebase.json")
        };

        FirebaseApp.Create(appOptions);

        services.AddSingleton<IAuthenticationService, AuthenticationService>();

        services.AddHttpClient<IJwtProvider, JwtProvider>((sp, httpClient) =>
        {
            var config = sp.GetRequiredService<IConfiguration>();

            var tokenUri = new Uri(config["Authentication:TokenUri"]);

            if (tokenUri is null)
                throw new ApplicationException("The TokenUri was not specified");

            httpClient.BaseAddress = tokenUri;
        });

        services
            .AddAuthentication()
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
            {
                jwtOptions.Authority = configuration["Authentication:ValidIssuer"];
                jwtOptions.Audience = configuration["Authentication:Audience"];
                jwtOptions.TokenValidationParameters.ValidIssuer = configuration["Authentication:ValidIssuer"];
            });

        return services;
    }
}
