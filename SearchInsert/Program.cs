public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target) return mid;
            else if (nums[mid] < target) left = mid + 1;
            else right = mid - 1;
        }

        return left;
    }

    public static void Main(string[] args)
    {
        Solution sol = new Solution();
        int[] nums = { 1, 3, 5, 6 };
        int target = 2;

        int index = sol.SearchInsert(nums, target);
        Console.WriteLine($"Number is at index {index}");
    }

}
