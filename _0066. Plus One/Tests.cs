using Xunit;

namespace _0066.PlusOne;

public class Tests
{
    /*
       Example 1:
       
       Input: digits = [1,2,3]
       Output: [1,2,4]
       Explanation: The array represents the integer 123.
       Incrementing by one gives 123 + 1 = 124.
       Thus, the result should be [1,2,4].
       Example 2:
       
       Input: digits = [4,3,2,1]
       Output: [4,3,2,2]
       Explanation: The array represents the integer 4321.
       Incrementing by one gives 4321 + 1 = 4322.
       Thus, the result should be [4,3,2,2].
       Example 3:
       
       Input: digits = [9]
       Output: [1,0]
       Explanation: The array represents the integer 9.
       Incrementing by one gives 9 + 1 = 10.
       Thus, the result should be [1,0].
     */
    
    [Theory]
    [InlineData(new []{1,2,3}, new []{1,2,4})]
    [InlineData(new []{4,3,2,1}, new []{4,3,2,2})]
    [InlineData(new []{9}, new []{1,0})]
    public void Solution_Execute_Ok(
        int[] passed, 
        int[] expected)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        var result = solution.PlusOne(passed);
        
        // Assert
        Assert.Equal(expected.Length, result.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }
}