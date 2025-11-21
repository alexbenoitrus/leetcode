using Xunit;

namespace _0058.LengthOfLastWord;

public class Tests
{
    [Theory]
    [InlineData("a", 1)]
    [InlineData("Hello World", 5)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("luffy is still joyboy", 6)]
    public void Solution_Execute_Ok(
        string passed, 
        int expected)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        var result = solution.LengthOfLastWord(passed);
        
        // Assert
        Assert.Equal(expected, result);
    }
}