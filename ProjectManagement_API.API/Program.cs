using Asp.Versioning;
using Azure;
using Azure.Messaging.ServiceBus;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjectManagement_API.API.ExceptionHandling;
using ProjectManagement_API.API.Validators;
using ProjectManagement_API.Application;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Core.Interfaces.Services;
using ProjectManagement_API.Infrastracture.Persistence;
using ProjectManagement_API.Infrastracture.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddApplication();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.MapInboundClaims = false;
        options.Authority = $"https://login.microsoftonline.com/{builder.Configuration["AzureAd:TenantId"]}";


        options.Audience =
          builder.Configuration["AzureAd:ClientId"];

        options.Audience = $"api://{builder.Configuration["AzureAd:ClientId"]}";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddAuthorization(options =>
{
    
    options.AddPolicy("adminrole_policy", policy => policy.RequireAuthenticatedUser()
    .RequireClaim("roles", "admin_role"));

});
builder.Services.AddScoped<IValidator<EmployeeRequestDto>, EmployeeValidator>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnection"))
);

builder.Services.AddApiVersioning(options =>
{
    //considers version 1.0 is default if request not having version
    //ex: /api/orders → treated as /api/v1/orders
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;

    //This adds version information to HTTP response headers.

    //Clients will see headers like:
    //api-supported-versions: 1.0, 2.0
    //api - deprecated - versions: 1.0

    options.ReportApiVersions = true;
}
    ).AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
    });


//service bus -start
var connectionString =
    builder.Configuration["AzureServiceBus:ConnectionString"]
    ?? throw new InvalidOperationException(
        "Azure Service Bus connection string is missing.");

var queueName =
    builder.Configuration["AzureServiceBus:QueueName"]
    ?? throw new InvalidOperationException(
        "Azure Service Bus queue name is missing.");

builder.Services.AddSingleton(
    _ => new ServiceBusClient(connectionString));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<ServiceBusClient>()
      .CreateSender(queueName));
//service bus -end

builder.Services.AddSingleton<IQueueMessageService,
                              QueueMessageService>();

var app = builder.Build();
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
