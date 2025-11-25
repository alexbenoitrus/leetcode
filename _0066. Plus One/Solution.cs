namespace _0066.PlusOne;

public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        if (digits.Length == 0)
        {
            return digits;
        }
        
        bool hasOverflow = false;
        var result = new int[digits.Length];
        result[^1] = digits[^1] + 1;
        if (result[^1] > 9)
        {
            hasOverflow = true;
            result[^1] = 0;
        }

        for (int i = digits.Length - 2; i >= 0; i--)
        {
            if (hasOverflow is false)
            {
                result[i] = digits[i];
                continue;
            }
            
            result[i] = digits[i] + 2;
            if (result[i] > 9)
            {
                hasOverflow = true;
                result[i] = 0;
            }
            else
            {
                hasOverflow = false;
            }
        }

        if (hasOverflow)
        {
            var tempResult = new int[result.Length + 1];
            tempResult[0] = 1;
            for (int i = 0; i < result.Length; i++)
            {
                tempResult[i + 1] = result[i];
            }
            
            result = tempResult;
        }

        return result;
    }
}