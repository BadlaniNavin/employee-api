using Employee.Infrastructure.Application.Features.GetAllEmployees;
using Employee.Infrastructure.Application.Repositories;
using Employee.Infrastructure.Persistence.Database;
using Employee.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(new[]
{
    typeof(Program).Assembly,
    typeof(GetAllEmployeesQuery).Assembly
});

builder
    .Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("employee")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// 1. Add Microsoft Identity JWT validation middleware
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();

// 2. Register the Swagger generator, defining one or more Swagger documents
builder.Services.AddEndpointsApiExplorer(); // Required for minimal APIs / modern controllers
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "My .NET API",
        Description = "An ASP.NET Core Web API documentation"
    });

    // Feed XML comments to Swagger
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    var tenantId = builder.Configuration["AzureAd:TenantId"];
    var apiClientId = builder.Configuration["AzureAd:ClientId"];

    // 1. Define OAuth2 Flow
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/authorize"),
                TokenUrl = new Uri($"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token"),
                Scopes = new Dictionary<string, string>
                {
                    { $"api://{apiClientId}/Employee.Read", "Read access to employee data" },
                    { $"api://{apiClientId}/Employee.Write", "Write access to employee data" }
                }
            }
        }
    });

    // 2. Add Security Requirement mapping (The step that was crashing)
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                }
            },
            new[] { $"api://{apiClientId}/Employee.Read", $"api://{apiClientId}/Employee.Write" }
        }
    });

});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
// 3. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

        // Optional: To serve the Swagger UI at the app's root (http://localhost:<port>/), 
        // set RoutePrefix to an empty string.
        // options.RoutePrefix = string.Empty;

        // Auto-inject the Swagger app registration Client ID
        options.OAuthClientId(builder.Configuration["AzureAd:ClientId"]);
        options.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();

// 3. Ensure Authentication runs before Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
