using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Softela.PestScheduler.Application.Core.Command;
using Softela.PestScheduler.Application.Core.Quey;

namespace Softela.PestScheduler.Application
{
    public static partial class BuilderExtensions
    {
        private static Assembly ApplicationAssembly => typeof(BuilderExtensions).Assembly;

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(ApplicationAssembly))
            .AddScoped<ICommandDispatcher, CommandDispatcher>()
            .AddScoped<IQueryDispatcher, QueryDispatcher>();

            return services;
        }
    }
}
