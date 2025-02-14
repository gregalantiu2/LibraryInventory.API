using LibraryInventory.API.Helpers;
using LibraryInventory.API.Middleware;
using LibraryInventory.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new() { Title = "LibraryInventory", Version = "v1" });
        c.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
        {
            Description = "OAuth2.0 - Authorization Flow",
            Name = "Authorization",
            Type = SecuritySchemeType.OAuth2,
            Flows = new OpenApiOAuthFlows
            {
                AuthorizationCode = new OpenApiOAuthFlow
                {
                    AuthorizationUrl = new Uri(builder.Configuration["SwaggerAuth:AuthorizationUrl"] ?? throw new ArgumentNullException("Swagger authorizationUrl not found")),
                    TokenUrl = new Uri(builder.Configuration["SwaggerAuth:TokenUrl"] ?? throw new ArgumentNullException("Swagger tokenUrl not found")),
                    Scopes = new Dictionary<string, string>
                    {
                        { builder.Configuration["SwaggerAuth:Scope"] ?? throw new ArgumentNullException("Swagger scopes not found"), "Access API as User" }
                    }
                }
            }
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "OAuth2"
                    }
                },
                new[] { builder.Configuration["SwaggerAuth:Scope"] }
            }
        });
    });

builder.Services.AddAutoMapper(Assembly.Load("LibraryInventory.Service"));

builder.Services.AddDbContext<LibraryInventoryDbContext>(options => 
    options.UseSqlServer(builder.Configuration["ConnectionStrings:LibraryInventoryDb"] ?? throw new ArgumentNullException("LibraryInventoryDb connection string not found")));

DependancyRegisterHelper.RegisterDependancies(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.OAuthClientId(builder.Configuration["SwaggerAuth:ClientId"]);
        c.OAuthUsePkce();
        c.OAuthScopeSeparator(" ");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleWare>();
app.UseMiddleware<UserContextMiddleware>();

app.Run();
