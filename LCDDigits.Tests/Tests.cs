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
        
        [Fact]
        public void GetLcdStringNumber_GivenOne_ReturnsOneStringRepresentation()
        {
            // Arrange
            const int number = 1;
            const string expectedResult = "...\n"+
                                          "..|\n"+ 
                                          "..|\n";
            
            // Act
            var actualResult = number.GetLcdStringNumber();
            
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        
        [Fact]
        public void GetLcdStringNumber_GivenSeveralOnes_ReturnsSeveralOnesStringRepresentation()
        {
            // Arrange
            const int number = 11;
            const string expectedResult = "......\n"+
                                          "..|..|\n"+ 
                                          "..|..|\n";
            
            // Act
            var actualResult = number.GetLcdStringNumber();
            
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}