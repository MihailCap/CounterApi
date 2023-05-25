using CounterApi.Domain;
using CounterApi.DTO;
using CounterApi.Persistence;
using CounterApi.Service;
using Microsoft.AspNetCore.Mvc;
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
app.MapGet("/counter", (ICounterService service) => service.GetAll().Select(x => x.toDto()).ToList())
    .WithTags("Counters")
    .WithName("Get all counters")
    .WithOpenApi();
//Get one by name
app.MapGet("/counter/{name}", ([FromRoute] string name, ICounterService service) => service.Get(name)?.toDto())
    .WithTags("Counters")
    .WithName("Get counter by name")
    .WithOpenApi();
//Create counter
app.MapPost("/counter", ([FromQuery] string name, ICounterService service) => service.Create(name)?.toDto())
    .WithTags("Counters")
    .WithName("Create counter")
    .WithOpenApi();
//Update counter
app.MapPut("/counter/{name}", ([FromRoute] string name,  [FromBody] CounterDto counter, ICounterService service) => service.Update(name, counter.Max, counter.Min, counter.Step, counter.Name)?.toDto())
    .WithTags("Counters")
    .WithName("Update counter")
    .WithOpenApi();
//Increment counter
app.MapPatch("/counter/{name}/increment", ([FromRoute] string name, ICounterService service) => service.Increment(name)?.toDto())
    .WithTags("Counters")
    .WithName("Increment counter")
    .WithOpenApi();
//Decrement counter
app.MapPatch("/counter/{name}/decrement", ([FromRoute] string name, ICounterService service) => service.Decrement(name)?.toDto())
    .WithTags("Counters")
    .WithName("Decrement counter")
    .WithOpenApi();
//Reset counter
app.MapPatch("/counter/{name}/reset", ([FromRoute] string name, ICounterService service) => service.Reset(name)?.toDto())
    .WithTags("Counters")
    .WithName("Reset counter")
    .WithOpenApi();
//Delete counter
app.MapDelete("/counter/{name}/delete", ([FromRoute] string name, ICounterService service) => service.Delete(name))
   .WithTags("Counters")
   .WithName("Delete counter")
   .WithOpenApi();
app.Run();
