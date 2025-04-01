// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * Find longest substring without repeating characters
 * Given a string s, find the length of the longest substring without repeating characters. Example 1: Input: s = "abcabcbb" Output: 3 Explanation: The answer is "abc", with the length of 3. Example 2: Input: s = "bbbbb" Output: 1 Explanation: The answer is "b", with the length of 1. Example 3: Input: s = "pwwkew" Output: 3 Explanation: The answer is "wke", with the length of 3. Notice that the answer must be a substring, "pwke" is a subsequence and not a substring. Constraints: 0 <= s.length <= 5 * 104 s consists of English letters, digits, symbols and spaces
 */

string s = "abcabcbb";
Solutionstring solution = new Solutionstring();
Console.WriteLine(solution.LengthOfLongestSubstring1(s));
Console.WriteLine(solution.LogestSubstring(s));

public class Solutionstring
{
    public int LengthOfLongestSubstring(string s)
    {
        int n = s.Length;
        int ans = 0;
        Dictionary<char, int> map = new Dictionary<char, int>(); // current index of character
        // try to extend the range [i, j]
        for (int j = 0, i = 0; j < n; j++)
        {
            if (map.ContainsKey(s[j]))
            {
                i = Math.Max(map[s[j]], i);
            }
            ans = Math.Max(ans, j - i + 1);
            map[s[j]] = j + 1;
        }
        return ans;
    }

    public int LengthOfLongestSubstring1(string s)
    {
        int left = 0;
        int right = 0;
        int max = 0;
        HashSet<char> set = new HashSet<char>();
        while (right < s.Length)
        {
            if (!set.Contains(s[right]))
            {
                set.Add(s[right]);
                max = Math.Max(max, set.Count);
                right++;
            }
            else
            {
                set.Remove(s[left]);
                left++;
            }
        }

        return max;
    }

    public string LogestSubstring(string str)
    {
        int iLongestSoFar = 0;
        int posLongestSoFar = 0;
        char charPrevious = ' ';
        int xCharacter = 0;
        int iCurrentLength = 0;
        while (xCharacter < str.Length)
        {
            //char charCurrent = str.Substring(xCharacter);
            char charCurrent = str[xCharacter];
            iCurrentLength++;
            if (charCurrent == charPrevious)
            {
                if (iCurrentLength > iLongestSoFar)
                {
                    iLongestSoFar = iCurrentLength;
                    posLongestSoFar = xCharacter;
                }
                iCurrentLength = 1;
            }
            charPrevious = charCurrent;
            xCharacter++;
        }
        if (iCurrentLength > iLongestSoFar)
        {
            return str.Substring(posLongestSoFar);
        }
        else
        {
            return str.Substring(posLongestSoFar, posLongestSoFar + iLongestSoFar);
        }
    }
}

public static class ExtensionMethods
{
    public static string Substring(this string str, int startIndex, int endIndex)
    {
        return str.Substring(startIndex, endIndex - startIndex);
    }
}