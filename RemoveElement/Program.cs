public class Solution {
      public int RemoveElement(int[] nums, int val)
    {
        int k = 0; 

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }

    public static void Main(string[] args)
    {
        int[] nums = { 3, 2, 2, 3 };
        int val = 3;

        Solution sol = new Solution();
        int k = sol.RemoveElement(nums, val);

        Console.WriteLine("New length: " + k);
        Console.WriteLine("Modified array:");
        for (int i = 0; i < k; i++)
        {
            Console.Write(nums[i] + " ");
        }
    }
}