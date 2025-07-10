public class Solution
{
    public int RomanToInt(string s)
    {
        var set = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int total = 0;
        int prevValue = 0;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            char c = s[i];
            int value = set[c];

            if (value < prevValue)
            {
                total -= value;
            }
            else
            {
                total += value;
                prevValue = value;
            }
        }

        return total;
    }

    public static void Main(string[] args)
    {
      Console.Write("Enter your Roman numeral: ");
        string romanExp = Console.ReadLine()!.ToUpper();

        Solution sol = new Solution();
        int romanToIntegerValue = sol.RomanToInt(romanExp);
        Console.WriteLine($"The Corresponding integer value is {romanToIntegerValue}");
    }
}