using _0026.RemoveDuplicatesFromSortedArray;
using Xunit;

namespace _26._Remove_Duplicates_from_Sorted_Array;

public class Tests
{
    [Theory]
    [InlineData(new []{1,1,2}, new []{1,2})]
    [InlineData(new []{0,0,1,1,1,2,2,3,3,4}, new []{0,1,2,3,4})]
    [InlineData(new int[]{}, new int[]{})]
    public void Solution_RomanToInt_Ok(
        int[] nums, 
        int[] expectedNums)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        int k = solution.RemoveDuplicates(nums); 
        
        // Assert
        Assert.Equal(expectedNums.Length, k);
        
        for (int i = 0; i < k; i++) {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }
}