using Xunit;

namespace _0021.MergeTwoSortedLists;

public class Tests
{
    [Theory]
    [InlineData(new []{1,2}, new []{1,2}, new []{1,1,2,2})]
    [InlineData(new []{1,2,4}, new []{1,3,4}, new []{1,1,2,3,4,4})]
    [InlineData(new int[0], new int[0], new int[0])]
    [InlineData(new int[0], new []{1}, new []{1})]
    public void Solution_RomanToInt_Ok(
        int[] list1, 
        int[] list2, 
        int[] expected)
    {
        // Arrange
        var solution = new Solution();
        
        // Act
        var result = solution.MergeTwoLists(
            ArrayToListNode(list1), 
            ArrayToListNode(list2));
        
        // Assert
        foreach (var val in expected)
        {
            Assert.NotNull(result);
            Assert.Equal(result.val, val);
            result = result.next;
        }

        Assert.Null(result);
    }

    private ListNode ArrayToListNode(int[] list)
    {
        ListNode prevNode = null;
        for (int i = list.Length-1; i >=0; i--)
        {
            prevNode = new ListNode(list[i], prevNode);
        }
        
        return prevNode;
    }
}