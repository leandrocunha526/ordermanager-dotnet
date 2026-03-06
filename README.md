# Order Manager

## API using Dotnet (cross platform) with JWT and IdentityModel

[![.NET](https://github.com/leandrocunha526/ordermanager-dotnet/actions/workflows/dotnet.yml/badge.svg)](https://github.com/leandrocunha526/ordermanager-dotnet/actions/workflows/dotnet.yml)
[![Build Status](https://dev.azure.com/leandrocunha520/ordermanager-dotnet/_apis/build/status/leandrocunha526.ordermanager-dotnet?branchName=main)](https://dev.azure.com/leandrocunha520/ordermanager-dotnet/_build/latest?definitionId=10&branchName=main)
[![LICENSE](https://img.shields.io/github/license/vitorserrano/task-manager?color=7159C1)](LICENSE.md)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)

## Integrated with Azure DevOps

- Use Windows Latest

## GitHub Actions

- Use Ubuntu Latest (LTS current)

## Description

To help manage:

- Warehouse,
- Culminate business intelligence,
- Statistics,
- To assist in decision making within the company with agricultural inputs, suppliers, work orders with registration and scheduling, machines, brands and models.

## Version

- Dotnet 9.0 STS

NOTE: The project is not compatible with Dotnet 10.0 yet, so it is recommended to use Dotnet 9.0 for now, because of the pending support for Pomelo.EntityFrameworkCore.MySql package, it is recommended to use Dotnet version 9.0 instead in Dotnet 10.x.

## SGBD

- MySQL Server (Tested with version 8.x)  
NOTE: MySQL Server 9.x is not compatible with Dotnet 10.0, so it is recommended to use MariaDB Server instead and the support is pending in Pomelo.EntityFrameworkCore.MySql package.
- MariaDB Server (Tested with version 10.x and 11.x)

## To run

`dotnet run`

or

`dotnet watch run`

## To create migrations

- EF Core Migrations: `dotnet ef migrations add InitialMigration`

## To create tables

`dotnet ef database update`

## Routes

Accessing `http://localhost:5000/swagger/index.html`

## Instructions to use Docker

- [Docker images for ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-8.0)

- [Docker images for MySQL Server](https://hub.docker.com/_/mysql)

- [Docker images for MariaDB Server (fork of the MySQL)](https://hub.docker.com/_/mariadb)

## Frontend

- [Order manager](https://github.com/leandrocunha526/ordermanager)

## Requirements

- MySQL Server (version 8.x)
- MariaDB (version 11.x)
- Dotnet (version 9.0)
- Dotnet EF (Entity Framework)
- Visual Studio Code or Visual Studio 2022
- Postman or Insomnia
- Dbeaver (optional)

## LICENSE

See [LICENSE](LICENSE.md)

## Docs

- [IdentityModel](https://identitymodel.readthedocs.io/en/latest/)
- [MySQL/MariaDB with Dotnet](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
- [Dotnet](https://docs.microsoft.com/en-us/dotnet/)
- [JWT](https://jwt.io/)
- [Auto Mapper](https://docs.automapper.org/en/stable/Getting-started.html)
- [Swagger](https://swagger.io/)
- [Azure DevOps](https://azure.microsoft.com/pt-br/services/devops/#overview)
- [Azure Pipelines](https://docs.microsoft.com/pt-br/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops&tabs=dotnetfive)

- [Explore Microsoft Open Source projects and initiative](https://opensource.microsoft.com/)
