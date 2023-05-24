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

        public ICounter? Create(string name)
        {
            if (name != null)  {
                try
                {
                    Counter C1 = new(name);
                    context.Counters.Add(C1);
                 
                    context.SaveChanges();
                    return C1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        public ICounter? Decrement(string name)
        {

            Counter counter = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if (counter != null)
            {
                counter.Decrement();
              
                context.SaveChanges();

            }
            return counter;
        }

        public bool Delete(string name)
        {
            Counter counter = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if(counter != null) 
            {
                context.Counters.Remove(counter);
                
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

           
        }

        public ICounter? Get(string name)
        {
            return context.Counters.FirstOrDefault(Counter => Counter.Name == name);
        }

        public IEnumerable<ICounter> GetAll()
        {
            foreach (var counter in context.Counters) { yield return counter; }
        }

        public ICounter? Increment(string name)
        {
            Counter counter = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if (counter != null)
            {
                counter.Increment();
             
                context.SaveChanges();

            }
            return counter;
            
        }

        public ICounter? Reset(string name)
        {
            Counter counter = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if (counter != null)
            {
                counter.Reset();

                context.SaveChanges();
            }
            return counter;

        }

        public ICounter? Update(string name, int? max, int? min, int? step, string? newName = null)
        {
            Counter counter = context.Counters.FirstOrDefault(Counter => Counter.Name == name);
            if (counter != null)
            {
                try
                {
                    if (newName != null && newName != name)
                    {

                        context.Counters.Remove(counter);
                        context.SaveChanges(true);
                        var updatedCounter = new Counter(newName);
                        updatedCounter.Update(min, max, step);
                        context.Counters.Add(updatedCounter);
                        context.SaveChanges();
                        return updatedCounter;
                    }
                    else
                    {
                        counter.Update(min, max, step ?? counter.Step);
                        context.SaveChanges() ;
                        return counter;
                    }
                   

                }
                catch (Exception)
                {
                    return null;
                }
                
                
            }
            return null;
        }
    }
}
