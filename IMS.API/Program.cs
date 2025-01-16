using DotNetEnv;
using IMS.DAL;
using IMS.DAL.Repositories;
using IMS.BLL.Services;
using IMS.BLL.Interfaces.Services;
using IMS.BLL.Interfaces.Repositories;
using IMS.API.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
Env.Load();

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
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "IMS API",
        Version = "v1",
        Description = "Inventory Management System API"
    });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Register Client Services
//builder.Services.AddScoped<IClientDashboardService, ClientDashboardService>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

// Register Authentication Services
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// Configure DbContext

// Debug configuration sources
Console.WriteLine("\n=== Configuration Sources ===");
foreach (var provider in ((IConfigurationRoot)builder.Configuration).Providers)
{
    Console.WriteLine($"Provider: {provider.GetType().Name}");
}

Console.WriteLine("\n**********************************");
Console.WriteLine("*      APPLICATION STARTING      *");
Console.WriteLine("**********************************\n");

// Replace environment variable section with direct configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("\n>>>>> CONNECTION STRING CHECK <<<<<");
Console.WriteLine($"Found: {!string.IsNullOrEmpty(connectionString)}");
Console.WriteLine($"Value: {connectionString}");
Console.WriteLine(">>>>> END CONNECTION STRING <<<<<\n");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration.");
}

Console.WriteLine($"\nUsing connection string from config: {connectionString}");

// Test database connectivity
using (var connection = new Npgsql.NpgsqlConnection(connectionString))
{
    try 
    {
        connection.Open();
        using (var cmd = connection.CreateCommand())
        {
            cmd.CommandText = "SELECT version()";
            var version = cmd.ExecuteScalar()?.ToString();
            Console.WriteLine($"PostgreSQL Version: {version}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Connection Error: {ex.Message}");
        throw; // Fail fast if db connection fails
    }
}

builder.Services.AddDbContext<IMSContext>(options =>
    options.UseNpgsql(connectionString)
           .ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
                       .Ignore(RelationalEventId.MultipleCollectionIncludeWarning)));

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Add after JWT Authentication configuration
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("WorkerAccess", policy => policy.RequireRole("Admin", "Worker"));
});    

// HTTP logging with detailed configuration
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    logging.RequestHeaders.Add("Authorization");
    logging.ResponseHeaders.Add("Content-Type");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<IMSContext>();
        await db.Database.MigrateAsync();
    }
}

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
else 
{
    // Disable HTTPS redirection in Production/Docker
    app.UseHsts();
}


Console.WriteLine("\n=== Configuration Debug ===");
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");
Console.WriteLine($"Connection String: {builder.Configuration.GetConnectionString("DefaultConnection")}");
Console.WriteLine("=========================\n");

// After builder creation
Console.WriteLine($"Content Root Path: {builder.Environment.ContentRootPath}");
Console.WriteLine("Available Files:");
Directory.GetFiles(builder.Environment.ContentRootPath).ToList().ForEach(f => Console.WriteLine(f));

// Important: Order matters for middleware
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpLogging();  // Before CORS and routing
app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


await app.RunAsync();

public partial class Program { }