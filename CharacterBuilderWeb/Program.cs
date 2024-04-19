using CharacterBuilderWeb.Components;

var builder = WebApplication.CreateBuilder(args);
// string uri = "http://thederpeningapiimage:8080";
string uri = Environment.GetEnvironmentVariable("apiaccess") ?? "http://characterbuilderweb-api:8080";
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<ApiService>(provider =>
{
    HttpClient httpclient = new HttpClient { BaseAddress = new Uri(uri) };
    return new ApiService(httpclient);
});



builder.Services.AddServerSideBlazor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
