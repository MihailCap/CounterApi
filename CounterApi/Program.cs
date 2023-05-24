using CounterApi.Persistence;
using CounterApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CounterDb>(opt => opt.UseInMemoryDatabase("CounterList"));
builder.Services.AddTransient<ICounterService, CounterService>();
var app = builder.Build();






app.Run();
