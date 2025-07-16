public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle)) return 0;

        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            int j = 0;
            while (j < needle.Length && haystack[i + j] == needle[j])
            {
                j++;
            }

            if (j == needle.Length)
            {
                return i;
            }
        }
        return -1;
    }

    public static void Main(string[] args)
    {
        string hayStack = "sadbutsad";
        string needle = "sad";
        Solution sol = new Solution();

        int index = sol.StrStr(hayStack, needle);

        Console.WriteLine($"The first occurence of the needle is at index {index}");
    }
}