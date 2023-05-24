using CounterApi.Persistence;
using CounterApi.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CounterDb>(opt => opt.UseInMemoryDatabase("CounterList"));
builder.Services.AddTransient<ICounterService, CounterService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Get all
app.MapGet("/counter", (ICounterService service) => service.GetAll())
    .WithTags("Counters")
    .WithName("Get all counters")
    .WithOpenApi();
//Get one by name
app.MapGet("/counter/{name}", () => { })
    .WithTags("Counters")
    .WithName("Get counter by name")
    .WithOpenApi();
//Create counter
app.MapPost("/counter", () => { })
    .WithTags("Counters")
    .WithName("Create counter")
    .WithOpenApi();
//Update counter
app.MapPut("/counter/{name}", () => { })
    .WithTags("Counters")
    .WithName("Update counter")
    .WithOpenApi();
//Increment counter
app.MapPatch("/counter/{name}/increment", () => { })
    .WithTags("Counters")
    .WithName("Increment counter")
    .WithOpenApi();
//Decrement counter
app.MapPatch("/counter/{name}/decrement", () => { })
    .WithTags("Counters")
    .WithName("Decrement counter")
    .WithOpenApi();
//Reset counter
app.MapPatch("/counter/{name}/reset", () => { })
    .WithTags("Counters")
    .WithName("Reset counter")
    .WithOpenApi();

app.Run();
