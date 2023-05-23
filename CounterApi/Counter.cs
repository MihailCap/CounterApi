namespace CounterApi
{
    public class Counter : ICounter
    {
        public int Value { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Step { get; set; }
        public void Increment()
        {
            Step > 0 ? Value += Step : Value++;
        }

        public void Decrement() { }

        public void Reset()
        {

        }

        public void Update(int Min, int Max, int Step)
        {

        }

  






    }
}