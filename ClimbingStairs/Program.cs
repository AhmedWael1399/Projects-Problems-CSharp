public class Solution {
    public int ClimbStairs(int n)
    {
        if (n == 1)
            return 1;
        if (n == 2)
            return 2;

        int[] dp = new int[n + 1];
        dp[1] = 1;
        dp[2] = 2;

        for (int i = 3; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }


    public static void Main(string[] args)
    {
        Solution sol = new Solution();
        int n = 5;
        Console.WriteLine($"The number of ways to climb the steps is {sol.ClimbStairs(n)}");
    }
}