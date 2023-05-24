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
app.MapGet("/counter/{name}", () => { });
//Create counter
app.MapPost("/counter", () => { });
//Update counter
app.MapPut("/counter/{name}", () => { });
//Increment counter
app.MapPatch("/counter/{name}/increment", () => { });
//Decrement counter
app.MapPatch("/counter/{name}/decrement", () => { });
//Reset counter
app.MapPatch("/counter/{name}/reset", () => { });

app.Run();
