using Datalytics.Task.WebAPI.DbConfigure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DatalyticsTaskDbContextCS");

builder.Services.AddControllers();
builder.Services.AddDbContext<DatalyticsTaskDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
