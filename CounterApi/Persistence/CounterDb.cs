using CounterApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CounterApi.Persistence
{
    public class CounterDb : DbContext
    {
        public DbSet<Counter> Counters => Set<Counter>();
        public CounterDb(DbContextOptions options) : base(options)
        {
        }
       
    }
}
