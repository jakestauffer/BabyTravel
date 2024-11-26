using BabyTravel.Calculator.Models;
using FluentAssertions;

namespace BabyTravel.Calculator.Tests
{
    public class DiaperTests
    {
        [Fact]
        public void CalculatesWithoutTravel()
        {
            // Arrange - Act
            var result = Diapers.For(Baby.WithBirthday(DateTime.Today));

            // Assert
            result.DiapersPerDay.Should().BeGreaterThan(0);
            result.TotalDiapers.Should().BeGreaterThan(0);
        }

        [Fact]
        public void CalculatesWithTravel()
        {
            // Arrange
            var diaperCalculationForSingleDay =
                Diapers.For(Baby.WithBirthday(DateTime.Today));

            var travel = Travel.Between(DateTime.Today, DateTime.Today.AddDays(1));

            // Act
            var result = diaperCalculationForSingleDay.Traveling(travel);

            // Assert
            result.DiapersPerDay.Should().Be(diaperCalculationForSingleDay.DiapersPerDay);
            result.TotalDiapers.Should().Be(diaperCalculationForSingleDay.DiapersPerDay * travel.Days);
        }

        [Theory]
        [InlineData(0, 12)]
        [InlineData(1, 10)]
        [InlineData(4, 10)]
        [InlineData(5, 9)]
        [InlineData(8, 9)]
        [InlineData(9, 7)]
        [InlineData(17, 7)]
        [InlineData(18, 5)]
        [InlineData(30, 5)]
        public void CalculatesDiapersPerDayByAgeRange(int ageInMonths, int expectedDiapersPerDay)
        {
            // Arrange
            var baby = Baby.WithBirthday(DateTime.Today.AddMonths(-ageInMonths));

            // Act
            var result = Diapers.For(baby);

            // Assert
            result.DiapersPerDay.Should().Be(expectedDiapersPerDay);
        }
    }
}