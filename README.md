# dotnet-ca-ecommerce
This project showcases a robust and scalable eCommerce application API built on the latest .NET 7 framework. Designed with a focus on maintainability and extensibility, this API employs the Clean Architecture principles, along with CQRS (Command Query Responsibility Segregation) and MediatR to deliver a cutting-edge solution.

## Database Configuration

Verify that the `DefaultConnection` connection string within `appsettings.json` points to a valid SQL Server instance.

## Database Migrations

For example, to add a new migration from the root folder:

```sh
dotnet ef migrations add "SampleMigration" --startup-project WebApi --project Infrastructure --output-dir Persistence\Migrations
```

To update the database from the root folder:

```sh
dotnet ef database update --startup-project WebApi
```

## Overview

### Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebApi
This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only Startup.cs should reference Infrastructure.

## Authentication
This project used Firebase to handle the authorization. If you want to check the endpoints you'll need to configure your [FireBase Configuration](https://console.firebase.google.com/).

At the appsetings.development.json you'll find the section to put your TokenUri, Audience and ValidIssuer

```sh
"Authentication": {
    "TokenUri": "YOUR-TOKEN-URI",
    "Audience": "YOUR-AUDIENCE",
    "ValidIssuer": "YOUR-VALID-ISSUER"
}
```

At the WebApi root folder you'll need to paste your Private Key file created that you can find it in the Account Services section of Firebase configuration.

## Technologies
- [ASP .NET Core 7](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [Entity Framework Core 7](https://learn.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)

