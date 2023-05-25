namespace CounterApi.DTO;

public class CounterDto
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int? Min { get; set; }
    public int? Max { get; set; }
    public int Step { get; set; }
}