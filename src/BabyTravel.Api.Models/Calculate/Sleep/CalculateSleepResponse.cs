using BabyTravel.Calculator.Models;

namespace BabyTravel.Api.Models.Calculate.Sleep
{
    public class CalculateSleepResponse
    {
        public IntRange NapsPerDay { get; set; }
        public DecimalRange WakeWindowInHours { get; set; }

        public DecimalRange TotalWakeHours { get; set; }
        public DecimalRange NapLengthInHours { get; set; }
        public DecimalRange SleepLengthInHours { get; set; }
        public DecimalRange TotalSleepInHours { get; set; }
    }
}
