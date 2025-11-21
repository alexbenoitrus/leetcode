namespace _0058.LengthOfLastWord;

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        int lastWordLength = 0;
        for (int i = s.Length-1; i >= 0 ; i--)
        {
            if (s[i] == ' ') 
                continue;
            
            while (true)
            {
                int currentPosition = i - lastWordLength;
                if (currentPosition < 0)
                    break;

                if (s[currentPosition] == ' ')
                    break;
                        
                lastWordLength++;
            }
                
            break;
        }

        return lastWordLength;
    }
}