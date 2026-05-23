# Softela PestScheduler

A .NET 9 solution for managing pest control scheduling, built with a clean architecture approach. The solution consists of API, Application, Infrastructure, and Domain projects.

## Projects

- **Softela.PestScheduler.API**  
  ASP.NET Core Web API project exposing endpoints for pest scheduling operations.

- **Softela.PestScheduler.Application**  
  Contains business logic, CQRS handlers, and MediatR integration.

- **Softela.PestScheduler.Infrastructure**  
  Handles data access (Dapper, SQL Server), migrations, and health checks.

- **Softela.PestScheduler.Domain**  
  Defines core domain models and entities.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (local or Azure)

### Configuration

Update `Softela.PestScheduler.API/appsettings.json` with your database connection details.

### API Documentation

OpenAPI/Swagger is available in development mode at `/swagger` or `/openapi`.

## Health Checks

The API exposes health checks for SQL Server. See `/health` endpoint.

## Migrations

Database migrations are applied automatically on startup via the Infrastructure project.

## Contributing

1. Fork the repository.
2. Create a feature branch.
3. Submit a pull request.
