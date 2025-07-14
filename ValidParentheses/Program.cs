public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> parenthesisStack = new Stack<char>();

        foreach (char c in s)
        {
            if (c == '(' || c == '{' || c == '[') parenthesisStack.Push(c);
            else if (c == ')' || c == '}' || c == ']')
            {
                if (parenthesisStack.Count == 0) return false;

                char top = parenthesisStack.Pop();
                if (c == ')' && top != '(' ||
                c == '}' && top != '{' ||
                c == ']' && top != '[') return false;
            }
       }

       return parenthesisStack.Count == 0;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.Write("Enter the Parenthesis expression you want: ");
        string str = Console.ReadLine()!;
        Console.WriteLine($"The Parenthesis expression is { solution.IsValid(str)}");
    }

}