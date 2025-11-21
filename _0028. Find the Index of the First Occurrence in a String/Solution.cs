namespace _0028.FindTheIndexOfTheFirstOccurrenceInAString;

public class Solution 
{
    public int StrStr(
        string haystack, 
        string needle)
    {
        if (haystack.Length == 0)
        {
            return needle.Length == 0 
                ? 0 
                : -1;
        }
        
        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            if(haystack[i] != needle[0])
                continue;

            int matchLength = 0;
            while (matchLength < needle.Length && haystack[i + matchLength] == needle[matchLength])
                matchLength++;

            if (matchLength == needle.Length)
                return i;
        }
        
        return -1;
    }   
}