using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TabelGPWebAPI.Data;
using TabelGPWebAPI.interfaces;
using TabelGPWebAPI.Services;

namespace TabelGPWebAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<INormsRepository, NormsRepository>();
            services.AddScoped<IMachinesRepository, MachinesRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IShiftsRepository, ShiftsRepository>();
            services.AddDbContext<ApplicationContext>(opt =>
                opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}