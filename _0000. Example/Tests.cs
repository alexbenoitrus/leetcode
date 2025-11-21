using Xunit;

namespace _0000.Example;

public class Tests
{
    [Theory]
    [InlineData("0", 0)]
    public void Solution_Execute_Ok(
        string passed, 
        int expected)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        var result = solution.Execute(passed);
        
        // Assert
        Assert.Equal(expected, result);
    }
}