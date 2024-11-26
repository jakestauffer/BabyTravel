using BabyTravel.Calculator.Models;
using FluentAssertions;

namespace BabyTravel.Calculator.Tests
{
    public class MealTests
    {
        private static Baby _baby = Baby.WithBirthday(DateTime.Today);
        private static Travel _travel = Travel.Between(DateTime.Today, DateTime.Today.AddDays(1));

        [Fact]
        public void CalculatesWithoutTravel()
        {
            // Arrange - Act
            var result = Meals.For(_baby);

            // Assert
        }

        [Fact]
        public void CalculatesWithTravel()
        {
            // Arrange
            var diaperCalculationForSingleDay = Meals.For(_baby);
            
            // Act
            var result = diaperCalculationForSingleDay.Traveling(_travel);

            // Assert
        }
    }
}