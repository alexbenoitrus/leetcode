using Xunit;

namespace _0028.FindTheIndexOfTheFirstOccurrenceInAString;

public class Tests
{
    [Theory]
    [InlineData("", "", 0)]
    [InlineData("sadbutsad", "sad", 0)]
    [InlineData("leetcode", "leeto", -1)]
    [InlineData("hello", "ll", 2)]
    [InlineData("a", "a", 0)]
    [InlineData("aaaaat", "at", 4)]
    [InlineData("aaat", "at", 2)]
    public void Solution_Execute_Ok(
        string haystack, 
        string needle, 
        int expected)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        var result = solution.StrStr(
            haystack: haystack, 
            needle: needle);
        
        // Assert
        Assert.Equal(expected, result);
    }
}