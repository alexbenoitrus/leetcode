using Xunit;

namespace _0027.RemoveElement;

public class Tests
{
    [Theory]
    [InlineData(new int[]{}, 0, new int[]{})]
    [InlineData(new int[]{3,2,2,3}, 3, new int[]{2,2})]
    [InlineData(new int[]{0,1,2,2,3,0,4,2}, 2, new int[]{0,1,3,0,4})]
    public void Solution_Execute_Ok(
        int[] nums, 
        int removed,
        int[] expectedNums)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        var result = solution.RemoveElement(nums, removed);
        
        // Assert
        Assert.Equal(expectedNums.Length, result);
        for (int i = 0; i < expectedNums.Length; i++) 
            Assert.Equal(expectedNums[i], nums[i]);
    }
}