using IMS.DAL;
using IMS.DAL.Repositories;
using IMS.BLL.Services;
using IMS.Interfaces.Services;
using IMS.Interfaces.Repositories;
using IMS.API.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add Application Insights and Logging
builder.Services.AddApplicationInsightsTelemetry();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddApplicationInsights();
builder.Logging.SetMinimumLevel(LogLevel.Information);

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder
                .WithOrigins(
                    "http://localhost:3000",     // React app
                    "https://localhost:3000",
                    "http://localhost:5079",     // API HTTP
                    "https://localhost:7237"     // API HTTPS
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(_ => true)   // Allow any origin
                .AllowCredentials();
        });
});

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "IMS API",
        Version = "v1",
        Description = "Inventory Management System API"
    });
});

// Register Services
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();

// Configure DbContext
builder.Services.AddDbContext<IMSContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("IMS.DAL")
    ));

// Add HTTP logging with detailed configuration
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    logging.RequestHeaders.Add("Authorization");
    logging.ResponseHeaders.Add("Content-Type");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMS API v1");
        c.RoutePrefix = "swagger";
    });
    app.UseDeveloperExceptionPage();
}

// Important: Order matters for middleware
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpLogging();  // Before CORS and routing
app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.RunAsync();