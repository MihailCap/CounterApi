using CounterApi.Domain;
using CounterApi.Persistence;

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
            throw new NotImplementedException();
        }

        public ICounter? Decrement(string name)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string name)
        {
            throw new NotImplementedException();
        }

        public ICounter? Get(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICounter> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICounter? Increment(string name)
        {
            throw new NotImplementedException();
        }

        public ICounter? Reset(string name)
        {
            throw new NotImplementedException();
        }

        public ICounter? Update(string name, int? max, int? min, int? step)
        {
            throw new NotImplementedException();
        }
    }
}
