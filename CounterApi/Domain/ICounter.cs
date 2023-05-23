namespace CounterApi.Domain
{
    public interface ICounter
    {
        string Name { get; }
        int Value { get; }
        int? Min { get; }
        int? Max { get; }
        int Step { get; }
        void Increment();
        void Decrement();
        void Reset();
        void Update(int? min, int? max, int step, string? name = null);
    }
}
