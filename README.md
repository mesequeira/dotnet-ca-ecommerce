# dotnet-ca-ecommerce
This project showcases a robust and scalable eCommerce application API built on the latest .NET 7 framework. Designed with a focus on maintainability and extensibility, this API employs the Clean Architecture principles, along with CQRS (Command Query Responsibility Segregation) and MediatR to deliver a cutting-edge solution.

## Configuración de la base de datos

Verifica que la cadena de conexión `DefaultConnection` dentro de `appsettings.json` apunte a una instancia válida de SQL Server.

## Migrations

Para agregar una nueva migración desde el root de la aplicación:

```sh
dotnet ef migrations add "SampleMigration" --startup-project WebApi --project Infrastructure --output-dir Persistence\Migrations
```

Para hacer un update de la base de datos desde el root de la aplicación:

```sh
dotnet ef database update --startup-project WebApi
```

## Descripción general

### Domain
Contiene todas las entidades, enums, excepciones, interfaces, tipos y lógica específica de la capa de Domain.

### Application
Contiene toda la lógica de negocio. Es dependiente de la capa de Domain, pero no tiene dependencias en ninguna otra capa o proyecto. Define las interfaces que van a ser implementadas en las capas exteriores. Por ejemplo, si Application necesita acceder a un products service, una nueva interface será instanciada y su implementacion será creada en Infrastructure.

### Infrastructure
Esta capa contiene clases para acceder a recursos externos como archivos de sistemas, web services, smpt, etc. Estas clases tienen que tener su interface definida en la capa de Application.

### WebApi
Esta capa depende de las capas de Application e Infrastructure; sin embargo, la dependencia de Infrastructure es solo para la inyección de dependencia. Entonces, sólo Startup.cs debe hacer referencia a Infrastructure.

- [ASP .NET Core 7](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [Entity Framework Core 7](https://learn.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)


