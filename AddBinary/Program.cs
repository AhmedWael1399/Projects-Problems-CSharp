public class Solution
{
    public string AddBinary(string a, string b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        string result = "";

        while (i >= 0 || j >= 0 || carry == 1)
        {
            int sum = carry;

            if (i >= 0)
            {
                sum += a[i] - '0'; 
                i--;
            }

            if (j >= 0)
            {
                sum += b[j] - '0';
                j--;
            }

            result = (sum % 2) + result;
            carry = sum / 2;
        }

        return result;
    }

    public static void Main(string[] args)
    {
        Solution s = new Solution();
        Console.WriteLine(s.AddBinary("11", "1"));       
        Console.WriteLine(s.AddBinary("1010", "1011"));  
    }
}
