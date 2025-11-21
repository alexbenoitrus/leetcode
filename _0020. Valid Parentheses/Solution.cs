using System.Collections.Generic;

namespace _0020.ValidParentheses;

public class Solution
{
    private static readonly HashSet<char> OpeningBrackets = new()
    {
        '(',
        '{',
        '['
    };

    private static readonly Dictionary<char, char> ClosingBracketMap
        = new()
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' },
        };
    
    public bool IsValid(string s)
    {
        var openedBrackets = new Stack<char>(s.Length);
        foreach (var currentBracket in s)
        {
            if (OpeningBrackets.Contains(currentBracket))
            {
                openedBrackets.Push(currentBracket);
                continue;
            }

            if (openedBrackets.Count == 0)
            {
                return false;
            }
            
            var lastOpenedBracket = openedBrackets.Pop();
            if (lastOpenedBracket != ClosingBracketMap[currentBracket])
            {
                return false;
            }
        }
        
        return openedBrackets.Count == 0;
    }
}