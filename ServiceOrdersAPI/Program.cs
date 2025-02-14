
using ServiceOrderManagement.Infrastructure.Extensions;
using ServiceOrdersManagement.Infrastructure.Configurations;
using System.Text.Json.Serialization;

namespace ServiceOrdersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers().AddJsonOptions(opts =>
            {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options => SwaggerGenCustomOptions.MountSwaggerGenOptions(options));

            builder.Services
                .AddApplicationServices()
                .AddInfrastructureServices(builder.Configuration)
                .AddJwtAuthentication(builder.Configuration);

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}
