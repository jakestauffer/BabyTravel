using BabyTravel.Calculator.Models;
using BabyTravel.Utilities;
using CSharpFunctionalExtensions;

namespace BabyTravel.Calculator
{
    // https://www.babysleepsite.com/naps/baby-naps-chart-how-many-how-long/
    public class Sleep
    {
        private Baby _baby;

        private Sleep(Baby baby)
        {
            _baby = baby;
        }

        public static Sleep For(Baby baby) => new(baby);

        public DecimalRange NapLengthInHours => _baby.AgeInMonths switch
        {
            <= 1 and < 3 => new DecimalRange(0.25m, 4),
            >= 3 and <= 4 => new DecimalRange(0.5m, 2),
            >= 5 and <= 6 => new DecimalRange(0.5m, 2),
            >= 7 and <= 8 => new DecimalRange(1, 2),
            >= 9 and <= 12 => new DecimalRange(1, 2),
            >= 13 and <= 17 => new DecimalRange(1, 3),
            _ => new DecimalRange(1.5m, 2.5m)
        };

        public Range NapsPerDay => _baby.AgeInMonths switch
        {
            <= 1 and < 3 => new Range(6, 8),
            >= 3 and <= 4 => new Range(4, 5),
            >= 5 and <= 6 => new Range(3, 4),
            >= 7 and <= 8 => new Range(2, 3),
            >= 9 and <= 12 => new Range(2, 2),
            >= 13 and <= 17 => new Range(1, 2),
            _ => new Range(1, 1)
        };

        public DecimalRange SleepLengthInHours =>
            new(24 - TotalNapHours.Max - TotalWakeHours.Max, 24 - TotalNapHours.Min - TotalWakeHours.Min);

        public DecimalRange WakeWindowInHours => _baby.AgeInMonths switch
        {
            <= 1 and < 3 => new DecimalRange(0.5m, 1),
            >= 3 and <= 4 => new DecimalRange(1, 2),
            >= 5 and <= 6 => new DecimalRange(2, 2),
            >= 7 and <= 8 => new DecimalRange(2, 3),
            >= 9 and <= 12 => new DecimalRange(2, 3),
            >= 13 and <= 17 => new DecimalRange(3, 5),
            _ => new DecimalRange(5, 6)
        };

        public DecimalRange TotalWakeHours =>
            new(WakeWindowInHours.Min + WakeWindowInHours.Min * NapsPerDay.Start.Value, WakeWindowInHours.Max + WakeWindowInHours.Max * NapsPerDay.End.Value);

        public DecimalRange TotalNapHours =>
             new(NapsPerDay.Start.Value * NapLengthInHours.Min, NapsPerDay.End.Value * NapLengthInHours.Max);

        public DecimalRange TotalSleepHours =>
             new(24 - TotalWakeHours.Max, 24 - TotalWakeHours.Min);
    }
}
