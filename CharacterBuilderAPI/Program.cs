using CharacterBuilderShared.Models;
using Microsoft.EntityFrameworkCore;


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

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
