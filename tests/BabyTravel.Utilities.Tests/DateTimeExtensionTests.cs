using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Utilities.Tests
{
    public class DateTimeExtensionTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(20)]
        [InlineData(-1)]
        [InlineData(-20)]
        public void CalculatesMonthsFromToday(int monthsInThePast)
        {
            // Arrange
            var date = DateTime.Today.AddMonths(-monthsInThePast);

            // Act
            var result = date.MonthsFromToday();

            // Assert
            result.Should().Be(monthsInThePast);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(20)]
        [InlineData(250)]
        [InlineData(-20)]
        public void CalculatesDaysBetweeDates(int daysInThePast)
        {
            // Arrange
            var date1 = DateTime.Today;
            var date2 = DateTime.Today.AddDays(-daysInThePast);

            // Act
            var result = date1.DaysFrom(date2);

            // Assert
            result.Should().Be(daysInThePast);
        }
    }
}
