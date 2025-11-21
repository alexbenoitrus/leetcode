namespace _0027.RemoveElement;

public class Solution 
{
    public int RemoveElement(
        int[] nums, 
        int removed) 
    {
        //Input: nums = [3,2,2,3], val = 3
        // Output: 2, nums = [2,2,_,_]
        
        if(nums.Length == 0)
            return 0;

        int removedCount = 0;
        int rigthBorder = nums.Length;
        for (int i = 0; i < rigthBorder; i++)
        {
            if (nums[i] == removed)
            {
                removedCount++;
                rigthBorder--;
                
                if (i == nums.Length - 1)
                {
                    break;
                }
                
                for (int j = i+1; j < nums.Length; j++)
                {
                    nums[j-1] = nums[j];
                }
            }

            if (nums[i] == removed)
                i--;
        }

        return nums.Length - removedCount;
    }
}