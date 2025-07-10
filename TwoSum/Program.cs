using System;
using System.Collections.Generic;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target) return new int[] { i, j };
            }

        }
        return null!;
    }
    public static void Main(string[] args)
    {
        Console.Write("Please Enter Target: ");
        int target = int.Parse(Console.ReadLine()!);

        Console.Write("Enter size of Number Array: ");
        int arraySize = int.Parse(Console.ReadLine()!);

        Console.WriteLine("\nNumber Array");
        int[] nums = new int[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            Console.Write($"Element # {i + 1}: ");
            nums[i] = int.Parse(Console.ReadLine()!);
        }

        Solution sol = new Solution();
        int[] result = sol.TwoSum(nums, target);
        
        if (result != null)
            Console.WriteLine($"Indices: [{result[0]}, {result[1]}]");
        else
            Console.WriteLine("No solution found!");
    }
}

