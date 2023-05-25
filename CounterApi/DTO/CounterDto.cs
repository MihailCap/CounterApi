using CounterApi.Domain;

namespace CounterApi.DTO;

public class CounterDto
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int? Min { get; set; }
    public int? Max { get; set; }
    public int Step { get; set; }

    public static CounterDto From(ICounter counter)
    {
        return new CounterDto
        {
            Name = counter.Name,
            Value = counter.Value,
            Min = counter.Min,
            Max = counter.Max,
            Step = counter.Step
        };
    }
}