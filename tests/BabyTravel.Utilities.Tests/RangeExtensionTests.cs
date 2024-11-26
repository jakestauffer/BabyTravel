using BabyTravel.Calculator.Models;
using FluentAssertions;

namespace BabyTravel.Utilities.Tests
{
    public class RangeExtensionTests
    {
        [Theory]
        [InlineData(1, 3, 0, 2)]
        [InlineData(0, 2, 1, 3)]
        [InlineData(2, 3, 1, 5)]
        public void Union(int minA, int maxA, int minB, int maxB)
        {
            // Arrange
            var range1 = new Range(minA, maxA);
            var range2 = new Range(minB, maxB);

            // Act
            var result = range1.Union(range2);

            // Assert
            result.Start.Value.Should().Be(Math.Min(minA, minB));
            result.End.Value.Should().Be(Math.Max(maxA, maxB));
        }

        [Theory]
        [InlineData(1, 3, 0)]
        [InlineData(0, 2, 1)]
        [InlineData(2, 3, 2)]
        public void Multiply(int min, int max, int multiplier)
        {
            // Arrange
            var range = new Range(min, max);

            // Act
            var result = range.Multiply(multiplier);

            // Assert
            result.Start.Value.Should().Be(min * multiplier);
            result.End.Value.Should().Be(max * multiplier);
        }
    }
}