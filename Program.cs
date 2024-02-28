using DockerTest.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var server = "localhost";
//var user = "SA"; // Warning do not use the SA account
//var password = "vV5r9tn0M4@";
//var database = "bookdb";
//var port = "1433";
//// Add Db context as a service to our application
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password};TrustServerCertificate=True"));
////builder.Services.AddDbContext<ApplicationDbContext>(option =>
////{
////    option.UseSqlServer(builder.Configuration.
////        GetConnectionString("DefaultConnection"));
////});
/* Database Context Dependency Injection */
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword}; TrustServerCertificate=True";
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));
/* ===================================== */

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
