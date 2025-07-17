public class Solution
{
    public int LengthOfLastWord(string s)
    {
        string[] words = s.Split(' ');
        int i = words.Length - 1;
        int length = 0;
        while (i >= 0)
        {
            if (words[i] != "") 
            {
                length = words[i].Length;
                return length;
            }
            i--;
        }
        return 0;
    }

    public static void Main(string[] args)
    {
        string sentence = "   fly me to the moon  ";
        Solution sol = new Solution();
/*
        string[] splits = sentence.Split(' ');
        foreach (string word in splits)
        {
            Console.WriteLine(word);
        }
*/
        int lengthOfLastWord = sol.LengthOfLastWord(sentence);

        Console.WriteLine($"The length of the last word is {lengthOfLastWord}");
    }
}