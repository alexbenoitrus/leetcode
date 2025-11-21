using Xunit;

namespace _0020.ValidParentheses;

public class Tests
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("{]", false)]
    [InlineData("([])", true)]
    [InlineData("([)]", false)]
    [InlineData("[", false)]
    [InlineData("]", false)]
    public void Solution_RomanToInt_Ok(
        string brackets, 
        bool expected)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        var result = solution.IsValid(brackets);
        
        // Asert
        Assert.Equal(expected, result);
    }
}