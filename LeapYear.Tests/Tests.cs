using System;
using Xunit;

namespace LeapYear.Tests
{
    public class Tests
    {
        [Fact]
        public void IsLeapYear_GivenLeapYear_ReturnsTrue()
        {
            // Arrange :D
            const int givenYear = 1984;
            const bool expectedFlag = true;

            // Act
            var result = LeapYear.IsLeapYear(givenYear);

            // Assert
            Assert.Equal(expectedFlag, result);
        }
        
        [Fact]
        public void IsLeapYear_GivenNotLeapYear_ReturnsFalse()
        {
            // Arrange :D
            const int givenYear = 1985;
            const bool expectedFlag = false;

            // Act
            var result = LeapYear.IsLeapYear(givenYear);

            // Assert
            Assert.Equal(expectedFlag, result);
        }
        
        [Fact]
        public void IsLeapYear_GivenHundredDivisibleNoFourHundredDivisibleYear_ReturnsFalse()
        {
            // Arrange :D
            const int givenYear = 1700;
            const bool expectedFlag = false;

            // Act
            var result = LeapYear.IsLeapYear(givenYear);

            // Assert
            Assert.Equal(expectedFlag, result);
        }
    }
}