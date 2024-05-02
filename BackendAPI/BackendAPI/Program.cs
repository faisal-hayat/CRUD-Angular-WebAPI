using BackendAPI.Database;
using BackendAPI.Services;
using BackendAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region add sql sever db context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("BackendAPI")
));
#endregion

#region add servcies
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
#endregion

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

#region set cors policy
app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
#endregion

app.Run();
