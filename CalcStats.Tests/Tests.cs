using System;
using Xunit;

namespace CalcStats.Tests
{
    public class Tests
    {
        [Fact]
        public void GetStatistic_GivenOneNumber_ReturnsMinimumValue()
        {
            // Arrange
            var numbers = new[] {1};
            const int expectedMinimum = 1;

            // Act
            var result = CalcStatistic.GetStatistic(numbers, CalcStatistic.StatisticType.Minimum);

            // Assert
            Assert.Equal(expectedMinimum, result);
        }
        
        [Fact]
        public void GetStatistic_GivenOneNumber_ReturnsMaximumValue()
        {
            // Arrange
            var numbers = new[] {1};
            const int expectedMaximum = 1;

            // Act
            var result = CalcStatistic.GetStatistic(numbers, CalcStatistic.StatisticType.Maximum);

            // Assert
            Assert.Equal(expectedMaximum, result);
        }
        
        [Fact]
        public void GetStatistic_GivenOneNumber_ReturnsSequenceLengthValue()
        {
            // Arrange
            var numbers = new[] {1};
            const int expectedLength = 1;

            // Act
            var result = CalcStatistic.GetStatistic(numbers, CalcStatistic.StatisticType.SequenceLength);

            // Assert
            Assert.Equal(expectedLength, result);
        }
        
        [Fact]
        public void GetStatistic_GivenOneNumber_ReturnsAverageValue()
        {
            // Arrange
            var numbers = new[] {1};
            const int expectedAverage = 1;

            // Act
            var result = CalcStatistic.GetStatistic(numbers, CalcStatistic.StatisticType.Average);

            // Assert
            Assert.Equal(expectedAverage, result);
        }
        
        [Fact]
        public void GetStatistic_GivenSeveralNumbers_ReturnsMinimumValue()
        {
            // Arrange
            var numbers = new [] {1, 2};
            const double expectedMinimum = 1;

            // Act
            var result = CalcStatistic.GetStatistic(numbers, CalcStatistic.StatisticType.Minimum);

            // Assert
            Assert.Equal(expectedMinimum, result);
        }
        
        [Fact]
        public void GetStatistic_GivenSeveralNumbers_ReturnsMaximumValue()
        {
            // Arrange
            var numbers = new[] {1, 2};
            const double expectedMaximum = 2;

            // Act
            var result = CalcStatistic.GetStatistic(numbers, CalcStatistic.StatisticType.Maximum);

            // Assert
            Assert.Equal(expectedMaximum, result);
        }
        
        [Fact]
        public void GetStatistic_GivenSeveralNumbers_ReturnsAverageValue()
        {
            // Arrange
            var numbers = new[] {1, 2};
            const double expectedAverage = 1.5;

            // Act
            var result = CalcStatistic.GetStatistic(numbers, CalcStatistic.StatisticType.Average);

            // Assert
            Assert.Equal(expectedAverage, result);
        }
    }
}