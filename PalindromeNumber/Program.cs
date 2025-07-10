public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;

        string numStr = x.ToString();
        for (int i = 0; i < numStr.Length / 2; i++)
        {
            if (numStr[i] != numStr[numStr.Length - 1 - i]) return false;
        }

        return true;
    }

    public static void Main(string[] args)
    {
        Console.Write("Please Enter the number you want to check: ");

        if (int.TryParse(Console.ReadLine(), out int num))
        {
            Solution sol = new Solution();
            if (sol.IsPalindrome(num))
                Console.WriteLine("Number is Palindrome");
            else
                Console.WriteLine("Number is not Palindrome");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}