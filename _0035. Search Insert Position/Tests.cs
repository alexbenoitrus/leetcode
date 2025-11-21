using Xunit;

namespace _0035.SearchInsertPosition;

public class Tests
{
    [Theory]
    [InlineData(new []{1,3,5,6}, 5, 2)]
    [InlineData(new []{1,3,5,6}, 2, 1)]
    [InlineData(new []{1,3,5,6}, 7, 4)]
    [InlineData(new []{1,3,5,6}, 0, 0)]
    [InlineData(new []{1,3,4,5,6,8,10}, 5, 3)]
    public void Solution_Execute_Ok(
        int[] nums, 
        int insertedValue,
        int expectedPositionForInsert)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        var result = solution.SearchInsert(nums, insertedValue);
        
        // Assert
        Assert.Equal(expectedPositionForInsert, result);
    }
}