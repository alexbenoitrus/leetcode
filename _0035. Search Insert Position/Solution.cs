namespace _0035.SearchInsertPosition;

public class Solution
{
    public int SearchInsert(
        int[] nums,
        int target)
    {
        if (nums[0] >= target)
            return 0;
        
        if(nums[^1] < target)
            return nums.Length;

        if (nums.Length == 0)
            return 0;
        
        int result = 0;
        
        
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Предотвращает переполнение

            if (nums[mid] == target)
                return mid; // Элемент найден
            
            if (nums[mid] < target)
                left = mid + 1; // Ищем в правой половине
            else
                right = mid - 1; // Ищем в левой половине
        }
        
        //
        // int middlePosition = ((nums.Length-1) / 2) + 1;
        // while (true)
        // {
        //     if(middlePosition == 0)
        //         return result;
        //     
        //     if(middlePosition >= nums.Length)
        //         return nums.Length;
        //     
        //     int posValue = nums[middlePosition];
        //     int leftValue = nums[middlePosition-1];
        //     if (leftValue < target && posValue >= target)
        //     {
        //         return middlePosition;
        //     }
        //
        //     if (posValue < target)
        //     {
        //         middlePosition = (middlePosition + (middlePosition / 2)) + 1;
        //     }
        //     else
        //     {
        //         middlePosition = (middlePosition - (middlePosition / 2));
        //     }
        // }
    }
}