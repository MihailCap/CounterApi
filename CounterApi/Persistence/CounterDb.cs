﻿using CounterApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CounterApi.Persistence
{
    public class CounterDb : DbContext
    {
        public HashSet<Counter> Counters { get; set; }
        public CounterDb(DbContextOptions options) : base(options)
        {
            Counters = new HashSet<Counter>();
        }
       
    }
}
