using CharacterBuilderWeb.Components;
using CharacterBuilderWeb.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;


var builder = WebApplication.CreateBuilder(args);
string uri = Environment.GetEnvironmentVariable("apiaccess") ?? "http://character-api:8080";

builder.Services.AddScoped<CharacterApiService>(provider =>
{
    HttpClient httpclient = new HttpClient { BaseAddress = new Uri(uri) };
    return new CharacterApiService(httpclient);
});

builder.Services.AddScoped<CharClassApiService>(provider =>
{
    HttpClient httpclient = new HttpClient { BaseAddress = new Uri(uri) };
    return new CharClassApiService(httpclient);
});

builder.Services.AddScoped<CharRaceApiService>(provider =>
{
    HttpClient httpclient = new HttpClient { BaseAddress = new Uri(uri) };
    return new CharRaceApiService(httpclient);
});

builder.Services.AddScoped<ModStatsApiService>(provider =>
{
    HttpClient httpclient = new HttpClient { BaseAddress = new Uri(uri) };
    return new ModStatsApiService(httpclient);
});

builder.Services.AddScoped<PlayerApiService>(provider =>
{
    HttpClient httpclient = new HttpClient { BaseAddress = new Uri(uri) };
    return new PlayerApiService(httpclient);
});

builder.Services.AddScoped<RaceVarApiService>(provider =>
{
    HttpClient httpclient = new HttpClient { BaseAddress = new Uri(uri) };
    return new RaceVarApiService(httpclient);
});

builder.Services.AddScoped<StatsApiService>(provider =>
{
    HttpClient httpclient = new HttpClient { BaseAddress = new Uri(uri) };
    return new StatsApiService(httpclient);
});

// builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();



// Add services to the container.
// builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
app.UseExceptionHandler("/Error", createScopeForErrors: true);
// }

app.UseHsts();
app.UseRouting();
app.UseStaticFiles();
app.UseAntiforgery();
// app.MapGet("/health", () => "Healthy");

app.MapHealthChecks("/health", new HealthCheckOptions
{
    AllowCachingResponses = false,
    ResultStatusCodes = {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

// app.MapBlazorHub();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
