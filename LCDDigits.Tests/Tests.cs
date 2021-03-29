using Xunit;

namespace LCDDigits.Tests
{
    public class Tests
    {
        [Fact]
        public void GetLcdStringNumber_GivenZero_ReturnsZeroStringRepresentation()
        {
            // Arrange
            const int number = 0;
            const string expectedResult = "._.\n" +
                                          "|.|\n" +
                                          "|_|\n";
            
            // Act
            var actualResult = number.GetLcdStringNumber();
            
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}