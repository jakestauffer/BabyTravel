using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Utilities
{
    public static class RangeExtensions
    {
        public static Range Union(this Range range1, Range range2) =>
            new Range(Math.Min(range1.Start.Value, range2.Start.Value), Math.Max(range1.End.Value, range2.End.Value));

        public static Range Multiply(this Range range, int multiple) =>
            new Range(range.Start.Value * multiple, range.End.Value * multiple);
    }
}
