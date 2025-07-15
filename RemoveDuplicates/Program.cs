public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        int k = 1;
        for (int i = 1; i < nums.Length; i++)
        {

            if (nums[i] != nums[k - 1])
            {
                nums[k] = nums[i];
                k++;
            }
        }
        return k;
    }

    public static void Main(string[] args)
    {
        int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
        Solution sol = new Solution();
        int k = sol.RemoveDuplicates(nums);

        Console.WriteLine("Number of unique elements: " + k);
        Console.WriteLine("Modified array:");
        for (int i = 0; i < k; i++)
        {
            Console.Write(nums[i] + " ");
        }
    }
}