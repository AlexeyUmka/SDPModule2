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
            const int number = 1;
            const int expectedMinimum = 1;

            // Act
            var result = CalcStatistic.GetStatistic(number);

            // Assert
            Assert.Equal(expectedMinimum, result);
        }
    }
}