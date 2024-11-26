using FluentAssertions;

namespace BabyTravel.Calculator.Models.Tests
{
    public class BabyTests
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 11, 11)]
        [InlineData(1, 0, 12)]
        [InlineData(2, 6, 30)]
        [InlineData(0, -1, -1)]
        [InlineData(-2, -6, -30)]
        public void CalculatesAgeInMonths(int years, int months, int expectedAgeInMonths)
        {
            // Arrange
            var birthday = DateTime.Today.AddYears(-years).AddMonths(-months);

            // Act
            var result = Baby.WithBirthday(birthday);

            // Assert
            result.AgeInMonths.Should().Be(expectedAgeInMonths);
        }
    }
}