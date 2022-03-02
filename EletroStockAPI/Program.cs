using AutoMapper;
using EletroStockAPI.Context;
using EletroStockAPI.Context.Repositories.Implementation;
using EletroStockAPI.Context.Repositories.Interfaces;
using EletroStockAPI.Utilities;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

//Add a configuration for the appsettings.json
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapConfig = new MapperConfiguration(config =>
{
    config.AddProfile(new AutoMapperConfig());
});

IMapper mapper = mapConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(configuration["ConnectionStrings:DbConnection"])
);


//Creates the relationship between a repository interface and its implementation
builder.Services.AddScoped<IUsersRepository, UsersRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
