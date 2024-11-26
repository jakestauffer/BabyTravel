using BabyTravel.Api.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Calculator.Models.Tests
{
    public class TravelTests
    {
        private static DateTime _today = DateTime.Today;

        [Fact]
        public void ThrowsWhenEndDateGreaterThanStartDate()
        {
            // Arrange
            var startDate = _today;
            var endDate = startDate.AddDays(-1);

            // Act
            var result = () => Travel.Between(startDate, endDate);

            // Assert
            result.Should().Throw<TravelEndDateLessThanStartDateException>();
        }

        [Fact]
        public void ThrowsWhenOnlyStartDateHasValue()
        {
            // Arrange
            var startDate = DateTime.Today;

            // Act
            var result = () => Travel.Between(startDate, null);

            // Assert
            result.Should().Throw<OneTravelDateSpecifiedException>();
        }

        [Fact]
        public void ThrowsWhenOnlyEndDateHasValue()
        {
            // Arrange
            var endDate = DateTime.Today;

            // Act
            var result = () => Travel.Between(null, endDate);

            // Assert
            result.Should().Throw<OneTravelDateSpecifiedException>();
        }

        [Fact]
        public void ReturnsSingleDayWhenNoDatesAreSpecified()
        {
            // Arrange - Act
            var result = Travel.Between(null, null);

            // Assert
            result.Days.Should().Be(1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void CalculatesDateDifference(int daysApart)
        {
            // Arrange
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(daysApart);

            // Act
            var result = Travel.Between(startDate, endDate);

            // Assert
            result.Days.Should().Be(daysApart + 1);
        }
    }
}
