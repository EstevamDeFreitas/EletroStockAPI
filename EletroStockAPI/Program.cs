using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Repositories.Implementation;
using Persistence.Repositories.Interfaces;
using Services.Middleware;
using Services.Services.Implementation;
using Services.Services.Interfaces;

namespace EletroStockAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IServiceWrapper, ServiceWrapper>();
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            builder.Services.AddDbContext<EletroStockContext>(options =>
            {
                options.UseNpgsql(configuration["ConnectionStrings:DbConnection"]);
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAll",
                                    policy =>
                                    {
                                        policy.AllowAnyOrigin();
                                        policy.AllowAnyMethod();
                                        policy.AllowAnyHeader();
                                    }
                                        );
            });

            var app = builder.Build();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");

            app.UseMiddleware<AuthMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}