# Order Manager

REST API built with **ASP.NET Core**, **Entity Framework Core**, **PostgreSQL**, **JWT authentication**, and **IdentityModel**.

[![.NET](https://github.com/leandrocunha526/ordermanager-dotnet/actions/workflows/dotnet.yml/badge.svg)](https://github.com/leandrocunha526/ordermanager-dotnet/actions/workflows/dotnet.yml)
[![Build Status](https://dev.azure.com/leandrocunha520/ordermanager-dotnet/_apis/build/status/leandrocunha526.ordermanager-dotnet?branchName=main)](https://dev.azure.com/leandrocunha520/ordermanager-dotnet/_build/latest?definitionId=10&branchName=main)
[![LICENSE](https://img.shields.io/github/license/vitorserrano/task-manager?color=7159C1)](LICENSE.md)

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)

## Description

Order Manager is an API designed to help manage business operations related to agricultural inputs and warehouse activities.

The project provides resources to manage:

- Warehouses;
- Agricultural inputs;
- Suppliers;
- Work orders;
- Work order scheduling;
- Machines;
- Brands and models;
- Statistics;
- Business intelligence data;
- Information used to assist business decision-making.

## Technologies

The project currently uses:

- .NET 10;
- ASP.NET Core;
- Entity Framework Core;
- PostgreSQL;
- Npgsql;
- JWT;
- IdentityModel;
- Swagger / OpenAPI;
- Docker;
- GitHub Actions;
- Azure DevOps.

## Version

The project currently targets:

```text
.NET 10.0
```

Check the installed .NET SDK version with:

```bash
dotnet --version
```

## Database

The application uses **PostgreSQL** as its database management system.

Recommended version:

```text
PostgreSQL 17+
```

PostgreSQL 17 or newer is recommended for development and deployment.

The application communicates with PostgreSQL through the **Npgsql Entity Framework Core provider**.

## Requirements

Before running the project, make sure the following dependencies are available:

- .NET 10 LTS;
- PostgreSQL 17 or newer;
- .NET Entity Framework CLI tools;
- Git;
- Visual Studio Code, Visual Studio 2022, or another compatible IDE;
- Postman or Insomnia for API testing;
- Docker and Docker Compose (optional);
- DBeaver or another PostgreSQL client (optional).

### Entity Framework CLI

Install the Entity Framework CLI tools:

```bash
dotnet tool install --global dotnet-ef
```

Verify the installation:

```bash
dotnet ef --version
```

## Configuration

The application configuration is loaded using the standard ASP.NET Core configuration providers.

Sensitive information such as JWT secrets and database credentials should **not be committed to the repository**.

### Database Connection

The application expects the following connection string:

```text
ConnectionStrings:Default
```

Example:

```json
{
  "ConnectionStrings": {
    "Default": "Host=localhost;Port=5432;Database=ordermanagerdb;Username=postgres;Password=YOUR_PASSWORD"
  }
}
```

For production environments, database credentials should be provided using environment variables or another secure secret management solution.

Using environment variables:

```env
ConnectionStrings__Default=Host=localhost;Port=5432;Database=ordermanagerdb;Username=postgres;Password=YOUR_PASSWORD
```

ASP.NET Core converts `__` (double underscore) to `:` when loading configuration values.

Therefore:

```text
ConnectionStrings__Default
```

corresponds to:

```text
ConnectionStrings:Default
```

## JWT Configuration

The application uses a secret key to sign and validate JWT tokens.

The expected configuration key is:

```text
AppSettings:Secret
```

The JWT secret should **not be stored directly in `appsettings.json` or committed to Git**.

### Development

For local development, use **.NET User Secrets**.

Initialize User Secrets if the project has not been configured yet:

```bash
dotnet user-secrets init
```

Configure the JWT secret:

```bash
dotnet user-secrets set "AppSettings:Secret" "YOUR_SECRET_KEY"
```

List the configured secrets:

```bash
dotnet user-secrets list
```

> Use a strong secret key and never commit it to the repository.

### Docker / Production

For Docker, staging, and production environments, the JWT secret can be provided using an environment variable:

```env
AppSettings__Secret=YOUR_SECRET_KEY
```

ASP.NET Core converts:

```text
AppSettings__Secret
```

to:

```text
AppSettings:Secret
```

This allows the `appsettings.json` file to contain only non-sensitive configuration:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## Running the Application

Restore the project dependencies:

```bash
dotnet restore
```

Build the project:

```bash
dotnet build
```

Run the application:

```bash
dotnet run
```

Alternatively, use watch mode during development:

```bash
dotnet watch run
```

## Entity Framework Migrations

Entity Framework Core migrations are used to manage the PostgreSQL database schema.

### Create a Migration

To create a new migration:

```bash
dotnet ef migrations add InitialMigration
```

For subsequent schema changes, use a descriptive migration name:

```bash
dotnet ef migrations add AddOrdersTable
```

### Apply Migrations

Apply pending migrations to the configured PostgreSQL database:

```bash
dotnet ef database update
```

### Remove the Latest Migration

If the latest migration has not been applied and needs to be removed:

```bash
dotnet ef migrations remove
```

> EF Core migrations are database-provider specific. Migrations used by previous database providers should not be reused after migrating the application to PostgreSQL.

## Production Migrations

For production environments, database migrations should preferably be executed as a separate deployment step.

Avoid granting unnecessary schema modification privileges to the application's runtime database user.

A recommended deployment flow is:

```text
Deploy
  |
  +-- Run database migrations
  |     |
  |     +-- Database user with DDL permissions
  |
  +-- Start application
        |
        +-- Runtime database user with minimum required permissions
```

This prevents the application runtime identity from requiring unnecessary schema modification privileges.

## Swagger

When running locally, the API documentation can be accessed through Swagger.

Example:

```text
http://localhost:5000/swagger/index.html
```

The actual port may vary depending on the application's launch configuration.

## Docker

The project can also be executed using Docker.

Docker can be used to run both:

- The ASP.NET Core API;
- PostgreSQL.

Example environment configuration:

```env
POSTGRES_DB=ordermanagerdb
POSTGRES_USER=postgres
POSTGRES_PASSWORD=YOUR_PASSWORD
```

The API can connect to the PostgreSQL container using a connection string similar to:

```env
ConnectionStrings__Default=Host=db;Port=5432;Database=ordermanagerdb;Username=postgres;Password=YOUR_PASSWORD
```

When using Docker Compose, `db` should match the PostgreSQL service name defined in `docker-compose.yml`.

### Docker Resources

- [Docker images for ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images)
- [Official PostgreSQL Docker Image](https://hub.docker.com/_/postgres)

## CI/CD

### GitHub Actions

GitHub Actions runs the project using:

```text
Ubuntu Latest
```

Workflow configuration:

```text
.github/workflows/dotnet.yml
```

### Azure DevOps

Azure DevOps pipelines use:

```text
Windows Latest
```

## Frontend

The frontend application is available at:

[Order Manager Frontend](https://github.com/leandrocunha526/ordermanager)

## Security

Never commit sensitive information to Git.

This includes:

- JWT signing keys;
- Database passwords;
- Connection strings containing credentials;
- API tokens;
- Private keys;
- Production secrets.

For local development, prefer:

```text
.NET User Secrets
```

For Docker, CI/CD, staging, and production environments, prefer:

```text
Environment Variables / Secret Management
```

Production environments should use an appropriate secret management solution whenever possible.

## License

See [LICENSE](LICENSE.md).

## Documentation

- [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/)
- [.NET](https://learn.microsoft.com/en-us/dotnet/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [Npgsql Entity Framework Core Provider](https://www.npgsql.org/efcore/)
- [PostgreSQL](https://www.postgresql.org/docs/)
- [IdentityModel](https://identitymodel.readthedocs.io/en/latest/)
- [JWT](https://jwt.io/)
- [Swagger](https://swagger.io/)
- [Docker](https://docs.docker.com/)
- [Azure DevOps](https://azure.microsoft.com/products/devops/)
- [Azure Pipelines for .NET](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core)
- [GitHub Actions for .NET](https://docs.github.com/en/actions/automating-builds-and-tests/building-and-testing-net)
- [Microsoft Open Source](https://opensource.microsoft.com/)

## AutoMapper Notice

The project uses AutoMapper.

For production use, verify the licensing requirements applicable to the AutoMapper version used by this project.

See:

[AutoMapper 15.0 Upgrade Guide](https://docs.automapper.io/en/stable/15.0-Upgrade-Guide.html)
