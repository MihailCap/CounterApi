namespace CounterApi
{
    public interface ICounter
    {
        int Value { get; }
        int? Min { get; }
        int? Max { get; }
        int Step { get; }
        void Increment();
        void Decrement();
        void Reset();
        void Update(int? min, int? max, int step);
    }
}
