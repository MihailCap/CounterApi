namespace CounterApi.Domain
{
    public class Counter : ICounter
    {


        public int Value { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int Step { get; set; }
        public string Name { get; set; }

        public Counter(string name)
        {
            Value = 0;
            Min = null;
            Max = null;
            Step = 1;
            Name = name;
        }


        public void Increment()
        {
            if (Max != null)
            {
                if (Value < Max)
                {
                    Value += Step;
                }
            }
            else
            {
                Value += Step;
            }


        }

        public void Decrement()
        {

            if (Min != null)
            {
                if (Value > Min)
                {
                    Value -= Step;
                }
            }
            else
            {
                Value -= Step;
            }

        }
        public void Reset()
        {
            Value = 0;
            Min = null;
            Max = null;
            Step = 1;
        }


        public void Update(int? min, int? max, int step, string name)
        {
            if (step > 0)
            {
                if (max != null && min != null)
                {
                    if (min < max)
                    {
                        Name = name;
                        Max = max;
                        Min = min;
                        Step = step;
                    }
                    else
                    {
                        throw new Exception("valore non valido");
                    }

                }
                else
                {
                    Name = name;
                    Max = max;
                    Min = min;
                    Step = step;
                }
            }
            else
            {
                throw new Exception("valore non valido");
            }
        }

        
    }
}