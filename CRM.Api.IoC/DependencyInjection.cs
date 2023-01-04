using CMR.Api.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CRM.Api.Application.Interfaces;
using CRM.Api.Infra.Data.Context;
using CRM.Api.Infra.Data.Repositories;
using CRM.Api.Application.Services;
using CRM.Api.Application.Mappings;

namespace CMR.Api.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
			string mySqlConnection = configuration.GetConnectionString("ConnectionMySql");
			services.AddDbContext<ApplicationDbContext>(options =>
					options.UseMySql(mySqlConnection,
						ServerVersion.AutoDetect(mySqlConnection)));

			//services.AddDbContext<ApplicationDbContext>(options =>
   //             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
   //                                 b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
   //          );

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddTransient<IClienteRabbitRepository, ClienteRabbitRepository>();
            services.AddTransient<IClienteRabbitService, ClienteRabbitService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            return services;
        }
    }
}
