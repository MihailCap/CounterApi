using System.ComponentModel.DataAnnotations;

namespace CounterApi.Domain
{
    public class Counter : ICounter
    {
        [Key]
        public string Name { get; set; }
        public int Value { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int Step { get; set; }

        public Counter(string name)
        {
            Name = name;
            Value = 0;
            Min = null;
            Max = null;
            Step = 1;

        }

        public void Increment()
        {
            if (Max != null)
            {
                if (Value < Max)
                {
                    int oldValue = Value;
                    Value += Step;
                   
                    if(Value > Max)
                    {
                        Value = oldValue;
                    }
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
                    int oldValue = Value;
                    Value -= Step;
                    
                    if (Value < Min)
                    {
                        Value = oldValue;
                    }
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


        public void Update(int? min, int? max, int? step)
        {
            if ((step != null && step <= 0) || (max != null && min != null && max <= min))
            {
                throw new Exception("valore non valido");
            }
            else
            {
                Min = min;
                Max = max;
                Step = step ?? Step;
                if (Value < Min)
                {
                    Value = Min.Value;
                }
                if (Value > Max)
                {
                    Value = Max.Value;
                }
            }
            
        }

        
    }
}