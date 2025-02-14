using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ServiceOrderManagement.Application.Interfaces;
using ServiceOrderManagement.Application.Services;
using ServiceOrderManagement.Infrastructure.Data;
using ServiceOrderManagement.Infrastructure.Repositories;
using ServiceOrdersManagement.Application.Interfaces;
using ServiceOrdersManagement.Application.Services;
using ServiceOrdersManagement.Domain.Interfaces;
using TarefasWeb.Configurations;

namespace ServiceOrderManagement.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();
            services.AddScoped<IServiceOrderService, ServiceOrderService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")
                                  ?? "Data Source=serviceorders.db"));

            services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            var jwtSettings = JwtSettings.MountJwtSettings(configuration);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = jwtSettings.createTokenValidationParameters();
            });

            return services;
        }
    }
}
