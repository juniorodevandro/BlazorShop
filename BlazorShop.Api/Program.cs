using BlazorShop.Api.Context;
using BlazorShop.Api.Interface;
using BlazorShop.Api.Repository;
using JWT.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Cors
builder.Services.AddCors();

// Configure DbContext
ConfigureDbContext(builder.Services, builder.Configuration);

// Interface
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7096", "http://localhost:5097")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Method to configure DbContext
void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
{
    var connectionString2 = configuration.GetConnectionString("EscalaDbConnection");
    var connectionString1 = configuration.GetConnectionString("DefaultDbConnection");

    if (string.IsNullOrWhiteSpace(connectionString1) || string.IsNullOrWhiteSpace(connectionString2))
    {
        throw new InvalidOperationException("As strings de conex�o n�o foram encontradas no arquivo appsettings.json.");
    }

    try
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString1);
        });

        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            //-- SE N�O CONSEGUIR SE CONECTAR EM UM TENTA EM OUTRO
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.OpenConnection();
            dbContext.Database.CloseConnection();
        }
    }
    catch
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString2);
        });
    }
}
