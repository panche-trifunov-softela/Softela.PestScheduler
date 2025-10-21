using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softela.PestScheduler.Application.Repositories;
using Softela.PestScheduler.Infrastructure.Database.Connections;
using Softela.PestScheduler.Infrastructure.Database.Dapper;
using Softela.PestScheduler.Infrastructure.Database.Migrator;
using Softela.PestScheduler.Infrastructure.Database.Repositories;

namespace Softela.PestScheduler.Infrastructure
{
    public static partial class BuilderExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var dbOptions = configuration.GetSection(DatabaseOptions.SectionName).Get<DatabaseOptions>();

            var connectionString = new DatabaseConnectionStringProvider(dbOptions, configuration).GetConnectionString();

            services.AddSingleton(dbOptions)
                .AddScoped<IDapperDataContext, DapperDataContext>()
                .AddScoped<IDatabaseConnection, DatabaseConnection>()
                .AddScoped<IDbMigrator, DbMigrator>();

            services.AddHealthChecks()
                .AddSqlServer(connectionString, "sqlserver");

            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();


            var serviceProviderFactory = new DefaultServiceProviderFactory();
            var serviceProvider = serviceProviderFactory.CreateServiceProvider(services);
            var dbMigrator = serviceProvider.GetRequiredService<IDbMigrator>();
            dbMigrator.Migrate();

            return services;
        }
    }
}
