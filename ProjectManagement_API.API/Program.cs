using Asp.Versioning;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement_API.API.ExceptionHandling;
using ProjectManagement_API.Application;
using ProjectManagement_API.Infrastracture.Persistence;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddApplication();
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



var app = builder.Build();
app.UseExceptionHandler();

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
