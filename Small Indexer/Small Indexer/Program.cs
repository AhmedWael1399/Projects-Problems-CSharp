using System.Globalization;

namespace Small_Indexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            #region Read Numbers From a Txt File and Creating a list of Numbers

            string filePath = "numbers.txt";
            List<long>? numList = new List<long>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                numList = lines.SelectMany(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                               .Select(long.Parse))
                                               .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return;
            }


            #endregion

            #region Identify Number of Duplicates and Place of Each

            List<long> uniqueNumList = new List<long>();

            for (int i = 0; i < numList.Count; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < uniqueNumList.Count; j++)
                {
                    if (numList[i] == uniqueNumList[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    uniqueNumList.Add(numList[i]);
                }
            }
            Console.WriteLine($"Number of numbers in list is = {uniqueNumList.Count}\n");

            #endregion

            #region Arrange them in a Numeric Form and Add To a New Txt File

            /*
            string outputFilePath = "numbersFormatted.txt";

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                int j = 0;
                int k = 1;
                Console.WriteLine();
                while (j < numList.Count)
                {

                    string formattedLine = $"{k}- {numList[j]}";
                    Console.WriteLine(formattedLine);
                    writer.WriteLine(formattedLine);
                    k++;
                    j++;
                }
            }
            */
            #endregion

            #region Identify The Number

            string outputFilePath = "numbersFormatted.txt";

            List<string> leadList = new List<string>();
            List<string> noLeadList = new List<string>();
            List<string> unknownList = new List<string>();
            List<string> allCategories = new List<string>();


            Console.WriteLine("Identify whether a Lead or No Lead:");
            for (int i = 0; i < uniqueNumList.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {uniqueNumList[i]}\n");
                Console.WriteLine("1- Lead");
                Console.WriteLine("2- No Lead");
                Console.WriteLine("3- Unknown");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine()!;

               
                switch (input)
                {
                    case "1":
                        leadList.Add($"{uniqueNumList[i]} - Lead");
                        break;
                    case "2":
                        noLeadList.Add($"{uniqueNumList[i]} - No Lead");
                        break;
                    case "3":
                        unknownList.Add($"{uniqueNumList[i]} - Unknown");
                        break;
                    default:
                        unknownList.Add($"{uniqueNumList[i]} - Unknown");
                        break;
                }

                Console.WriteLine(); 
            }
            Console.WriteLine("=== After Categorizing ===\n\n");
            if (leadList.Count > 0)
            {
                Console.WriteLine("Lead Results:");
                for (int i = 0; i < leadList.Count; i++)
                {
                    Console.WriteLine($"{leadList[i]}");
                }
                allCategories.Add("=== Leads ===");
                allCategories.AddRange(leadList);
                allCategories.Add("");
                Console.WriteLine();
            }

            if (noLeadList.Count > 0)
            {
                Console.WriteLine("No Leads Results:");
                for (int i = 0; i < noLeadList.Count; i++)
                {
                    Console.WriteLine($"{noLeadList[i]}");
                }
                allCategories.Add("=== No Leads ===");
                allCategories.AddRange(noLeadList);
                allCategories.Add("");
                Console.WriteLine();
            }
           
            if (unknownList.Count > 0)
            {
                Console.WriteLine("Unknown Results:");
                for (int i = 0; i < unknownList.Count; i++)
                {
                    Console.WriteLine($"{unknownList[i]}");
                }
                allCategories.Add("=== Unknown ===");
                allCategories.AddRange(unknownList);
            }

            File.WriteAllLines(outputFilePath, allCategories);
            Console.ReadLine();

            #endregion
        }
    }
}
