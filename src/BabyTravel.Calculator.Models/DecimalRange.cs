using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Calculator.Models
{
    public class DecimalRange
    {
        public decimal Min { get; }
        public decimal Max { get; }

        public DecimalRange(decimal min, decimal max)
        {
            Min = min;
            Max = max;
        }

        public DecimalRange(Range range)
        {
            Min = range.Start.Value;
            Max = range.End.Value;
        }
    }
}
