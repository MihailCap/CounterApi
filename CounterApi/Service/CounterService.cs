using CounterApi.Domain;
using CounterApi.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CounterApi.Service
{
    public class CounterService : ICounterService
    {
        private readonly CounterDb context;

        public CounterService(CounterDb context)
        {
            this.context = context;
        }

        public ICounter Create(string name)
        {
            if (name == null || name == "") { throw new ArgumentNullException("name empty"); }else {
                Counter C1 = new(name);
                context.Counters.Add(C1);
                return C1;
            }
        }

        public ICounter Decrement(string name)
        {

            Counter c1 = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if (c1 != null)
            {
                c1.Decrement();
                return c1;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool Delete(string name)
        {
            Counter c1 = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if(c1 != null) 
            {
                return context.Counters.Remove(c1);
            } else
            {
                throw new NotImplementedException();
            }
            
            
        }

        public ICounter Get(string name)
        {
            Counter c1 = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if (c1 != null)
            {
                return c1;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<ICounter> GetAll()
        {
            foreach (var counter in context.Counters) { yield return counter; }
        }

        public ICounter Increment(string name)
        {
            Counter c1 = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if (c1 != null)
            {
                c1.Increment();
                return c1;
            }
            else
            {
                throw new NotImplementedException();
            }
            
        }

        public ICounter Reset(string name)
        {
            Counter c1 = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if (c1 != null)
            {
                c1.Reset();
                return c1;
            }
            else
            {
                throw new NotImplementedException();
            }
           
        }

        public ICounter Update(int? min, int? max, int step, string name)
        {
            Counter c1 = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if (c1 != null)
            {
                c1.Update(min, max, step, name);
                return c1;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
