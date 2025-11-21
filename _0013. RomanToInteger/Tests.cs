using Xunit;

namespace _0013.RomanToInteger;

public class Tests
{
    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void Solution_RomanToInt_Ok(
        string roman, 
        int expected)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        var result = solution.RomanToInt(roman);
        
        // Asert
        Assert.Equal(expected, result);
    }
}