using Microsoft.EntityFrameworkCore;
using phase3_api2.AppService;
using phase3_api2.Domain.Interface;
using phase3_api2.Infrastructure;


using FluentValidation;
using FluentValidation.AspNetCore;
using phase3_api2.Domain.DTO;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Version = "v1",
            Title = "FridgeLogger API",
            Description = "An ASP.NET Core Web API for storing fridge item information" +
            " (product name, time stored, time taken out, expiry time, wasted or not) from IoT products." +
            " The information is collected anonymously and can be used by anyone for research" +
            " purposes. "

        });

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
    );

//add custom services
builder.Services.AddScoped<IProdService, ProdService>();
builder.Services.AddScoped<IProdRepository, ProdRepository>();

//add fluent validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateProdDto>, CreateProdDtoValidator>();
builder.Services.AddScoped<IValidator<TakeProdDto>, TakeProdDtoValidator>();

//add db context
var connectionString = builder.Configuration.GetConnectionString("phase3-azure");
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
