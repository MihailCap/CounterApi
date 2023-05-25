using CounterApi.DTO;

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
        void Update(int? min, int? max, int? step);
    }

    public static class ICounterExtension
    {
        public static CounterDto toDto(this ICounter counter)
        {
            return CounterDto.From(counter);
        }
    }
}
