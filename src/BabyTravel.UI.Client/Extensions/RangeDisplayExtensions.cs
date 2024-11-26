using BabyTravel.Api.Client;

namespace BabyTravel.UI.Client.Extensions
{
    public static class RangeDisplayExtensions
    {
        public static string ToStringBetween(this DecimalRange range)
        {
            if (range.Min == range.Max)
            {
                return range.Max.ToString();
            }

            return $"{range.Min} to {range.Max}";
        }

        public static string ToStringBetween(this IntRange range)
        {
            if (range.Min == range.Max)
            {
                return range.Max.ToString();
            }

            return $"{range.Min} to {range.Max}";
        }

        public static string ToStringUpTo(this DecimalRange range)
        {
            if (range.Max == 0)
            {
                return "0";
            }

            return $"up to {range.Max}";
        }

        public static string ToStringUpTo(this IntRange range)
        {
            if (range.Max == 0)
            {
                return "0";
            }

            return $"up to {range.Max}";
        }
    }
}
