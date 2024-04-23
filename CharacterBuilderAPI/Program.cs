using CharacterBuilderShared.Models;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// var connectionstring = builder.Configuration["ListDb"];
var connectionstring = builder.Configuration.GetConnectionString("ListDb");

builder.Services.AddDbContext<BuilderContext>(options => options.UseNpgsql(connectionstring));

builder.Services.AddScoped<CharacterService>();
builder.Services.AddScoped<CharClassService>();
builder.Services.AddScoped<CharRaceService>();
builder.Services.AddScoped<ModStatsService>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<RaceVarService>();
builder.Services.AddScoped<StatsService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string serviceName = "CharactersandPlayers";

builder.Logging.AddOpenTelemetry(options =>
{
    options
        .SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName))
        .AddOtlpExporter(o =>
            {
                o.Endpoint = new Uri("http://derp-otel-collector:4317");
            });
});



builder.Services.AddOpenTelemetry()
      .ConfigureResource(resource => resource.AddService(serviceName))
      .WithTracing(tracing => tracing
          .AddAspNetCoreInstrumentation()
          //   .AddConsoleExporter()
          .AddSource(CharacterMonitoring.charactermetricstring)
          .AddOtlpExporter(o =>
          {
              o.Endpoint = new Uri("http://derp-otel-collector:4317");
          }))
      .WithMetrics(metrics => metrics
          .AddAspNetCoreInstrumentation()
          .AddMeter("charactermetrics")
          //   .AddConsoleExporter()
          .AddPrometheusExporter()
          .AddOtlpExporter(o =>
          {
              o.Endpoint = new Uri("http://derp-otel-collector:4317");
          }));

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.MapHealthChecks("/health", new HealthCheckOptions
{
    AllowCachingResponses = false,
    ResultStatusCodes = {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

app.MapGet("/", () =>
{
    CharacterMonitoring.interactivecounter += 1;
});
// app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
