﻿using System.ComponentModel.DataAnnotations;

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
                    Value += Step;
                    int oldValue = Value;
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
                    Value -= Step;
                    int oldValue = Value;
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
            if ( (step != null && step <= 0) || (max != null && min != null && max <= min))
            {
                throw new Exception("valore non valido");
            }
            Min = min;
            Max = max;
            Step = step ?? Step;
        }

        
    }
}