using CounterApi.Domain;

namespace CounterApi.Service
{
    public interface ICounterService
    {
        IEnumerable<ICounter> GetAll();
        ICounter? Get(string name);
        ICounter? Create(string name);
        ICounter? Update(string name, int? max, int? min, int? step, string? newName = null);
        ICounter Increment(string name);
        ICounter Decrement(string name);
        ICounter Reset(string name);
        bool Delete(string name);

    
    }
}
