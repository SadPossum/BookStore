using BookStore.Api.Configurations;
using BookStore.Api.Endpoints;
using BookStore.Api.Extensions;
using BookStore.Api.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("Content-Disposition"));

app.UseSerilogRequestLogging();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseHsts();

app.UseRouting();

app.UseAuthorization();

app.MapModuleEndpoints<Books>()
    .MapModuleEndpoints<Orders>();

app.Run();





