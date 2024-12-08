using IMS.DAL;
using IMS.DAL.Repositories;
using IMS.BLL.Services;
using IMS.Interfaces;
using IMS.API.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder
                .WithOrigins("http://localhost:3000") // URL of React app
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); // Ensure credentials are allowed if needed
        });
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "IMS API", Version = "v1" });
});

// Register the CategoryService and ICategoriesService
builder.Services.AddScoped<ICategoriesService, CategoriesService>(); // BLL
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>(); // DAL

// Register the ItemService and IItemService
builder.Services.AddScoped<IItemService, ItemService>(); // BLL
builder.Services.AddScoped<IItemRepository, ItemRepository>(); // DAL

// Register the StockService and IStockService
builder.Services.AddScoped<IStockService, StockService>(); // BLL
builder.Services.AddScoped<IStockRepository, StockRepository>(); // DAL

// Add the DbContext
builder.Services.AddDbContext<IMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMS API v1");
    });
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();