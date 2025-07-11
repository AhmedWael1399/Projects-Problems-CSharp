public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0)
            return "";

        string prefix = strs[0];

        for (int i = 1; i < strs.Length; i++)
        {
            while (!strs[i].StartsWith(prefix))
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
                if (prefix == "")
                    return "";
            }
        }

        return prefix;
    }

    public static void Main(string[] args)
    {
        string[] strs1 = { "flower", "flow", "flight" };
        string[] strs2 = { "dog", "racecar", "car" };

        Solution sol = new Solution();
        Console.WriteLine("Example 1 Output: " + sol.LongestCommonPrefix(strs1));
        Console.WriteLine("Example 2 Output: " + sol.LongestCommonPrefix(strs2));

    }
}