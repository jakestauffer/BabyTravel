using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Calculator.Models
{
    public class IntRange
    {
        public int Min { get; }
        public int Max { get; }

        public IntRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public IntRange(Range range)
        {
            Min = range.Start.Value;
            Max = range.End.Value;
        }
    }
}
