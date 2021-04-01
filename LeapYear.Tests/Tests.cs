using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        
        [Fact]
        public void IsLeapYear_GivenHundredDivisibleFourHundredDivisibleYear_ReturnsTrue()
        {
            // Arrange :D
            const int givenYear = 1600;
            const bool expectedFlag = true;

            // Act
            var result = LeapYear.IsLeapYear(givenYear);

            // Assert
            Assert.Equal(expectedFlag, result);
        }

        [Theory]
        [ClassData(typeof(GetYearsRange))]
        public void IsLeapYear_GivenRangeOfYears_ReturnsValueAsNativeMicrosoftFunction(int year)
        {
            // Act
            var isLeapYear = LeapYear.IsLeapYear(year);

            // Assert
            Assert.Equal(DateTime.IsLeapYear(year), isLeapYear);
        }
        
        private class GetYearsRange : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                for (int i = 1; i < 9999; i++)
                {
                    yield return new object[]{i};
                }
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();            
        }
    }
}