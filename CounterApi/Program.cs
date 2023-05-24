using CounterApi.Persistence;
using CounterApi.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CounterDb>(opt => opt.UseInMemoryDatabase("CounterList"));
builder.Services.AddTransient<ICounterService, CounterService>();
var app = builder.Build();

// Get all
app.MapGet("/counter", (ICounterService service) => service.GetAll());
//Get one by name
app.MapGet("/counter/{name}", (string name, ICounterService service) => service.Get(name));
//Create counter
app.MapPost("/counter", (string name, ICounterService service) => service.Create(name));
//Update counter
app.MapPut("/counter/{name}", (string name, ) => { });
//Increment counter
app.MapPatch("/counter/{name}/increment", (string name, ICounterService service) => service.Increment(name));
//Decrement counter
app.MapPatch("/counter/{name}/decrement", (string name, ICounterService service) => service.Decrement(name));
//Reset counter
app.MapPatch("/counter/{name}/reset", (string name, ICounterService service) => service.Reset(name) );

app.Run();
