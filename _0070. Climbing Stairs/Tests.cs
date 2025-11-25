using Xunit;

namespace _0070.ClimbingStairs;

public class Tests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(6, 13)]
    public void Solution_Execute_Ok(
        int passed, 
        int expected)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        var result = solution.ClimbStairs(passed);
        
        // Assert
        Assert.Equal(expected, result);
    }
}