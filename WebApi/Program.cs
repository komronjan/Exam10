using Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(conf => conf.UseNpgsql(connection));
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<ManagerService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
