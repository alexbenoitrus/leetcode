using System.Collections.Generic;

namespace _0013.RomanToInteger;

public class Solution
{
    private static readonly Dictionary<char, int> _romanToInt
        = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };
    
    public int RomanToInt(string romanString)
    {
        int result = 0;
        for (int i = romanString.Length-1; i >= 0; i--)
        {
            char currenRomanString = romanString[i];
            int current = _romanToInt[currenRomanString];
            if (i == 0)
            {
                result += current;
                continue;
            }
            
            int nextPosition = i - 1;
            char nextRomanString = romanString[nextPosition];
            int next = _romanToInt[nextRomanString];
            if (current <= next)
            {
                result += current;
                continue;
            }

            int minusValue = next;
            i--;
            
            while (true)
            {
                nextPosition--;
                if (nextPosition < 0)
                    break;

                nextRomanString = romanString[nextPosition];
                next = _romanToInt[nextRomanString];
                if (next >= current)
                    break;
                
                minusValue+= next;
                i--;
            }

            current -= minusValue;
            result += current;
        }
        
        return result;
    }
}