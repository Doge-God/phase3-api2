using Microsoft.EntityFrameworkCore;
using phase3_api2.AppService;
using phase3_api2.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add custom services
builder.Services.AddScoped<IProdService, ProdService>();
builder.Services.AddScoped<IProdRepository, ProdRepository>();

//add db context
var connectionString = builder.Configuration.GetConnectionString("phase3-local2");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

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
