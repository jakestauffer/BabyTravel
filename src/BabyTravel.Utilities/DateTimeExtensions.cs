namespace BabyTravel.Utilities
{
    public static class DateTimeExtensions
    {
        private const int DaysPerMonth = 30;

        public static int MonthsFromToday(this DateTime date) =>
            DateTime.Today.DaysFrom(date) / DaysPerMonth;

        public static int DaysFrom(this DateTime date1, DateTime date2) =>
            (date1 - date2).Days;
    }
}
