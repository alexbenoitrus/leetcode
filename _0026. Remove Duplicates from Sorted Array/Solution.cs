using System.Collections.Generic;

namespace _0026.RemoveDuplicatesFromSortedArray;
public class Solution 
{
    public int RemoveDuplicates(int[] nums) 
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        
        int lastUniqueIndex = 0;
        for (int i = 1; i < nums.Length; i++)
            if (nums[lastUniqueIndex] != nums[i])
                nums[++lastUniqueIndex] = nums[i];
        
        return lastUniqueIndex + 1;
    }
    
    public int RemoveDuplicates2(int[] nums) 
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        
        var result = new List<int>();
        int lastAddedIndex = 0;
        result.Add(nums[0]);

        for (int i = 1; i < nums.Length; i++)
        {
            int num = nums[i];
            if (num > result[lastAddedIndex])
            {
                result.Add(num);
                lastAddedIndex++;
            }
        }

        for (int i = 0; i < result.Count; i++)
        {
            nums[i] = result[i];
        }

        return result.Count;
    }
}