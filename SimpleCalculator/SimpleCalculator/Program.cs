internal class Program
{
    static int Addition(int num1, int num2)
    {
        int total = num1 + num2;
        return total;
    }

    static int Subtraction(int num1, int num2)
    {
        int total = num1 - num2;
        return total;
    }

    static int Multiplication(int num1, int num2)
    {
        int total = num1 * num2;
        return total;
    }

    static double Division(int num1, int num2)
    {
        int total = num1 / num2;
        return total;
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Simple Calculator");
        Console.Write("Choose a functionality:");
        int num1 = Convert.ToInt32(Console.ReadLine()), num2, num3, sum, difference, multiplying;
        double divisioning;
        switch (num1)
        {
            case 1:
                Console.WriteLine("Addition");
                Console.Write("Enter the first number:");
                num2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the second number:");
                num3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Addition:{Addition(num2, num3)}");
                break;

            case 2:
                Console.WriteLine("Subtraction");
                Console.Write("Enter the first number:");
                num2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the second number:");
                num3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Subtraction:{Subtraction(num2, num3)}");
                break;

            case 3:
                Console.WriteLine("Multiplication");
                Console.Write("Enter the first number:");
                num2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the second number:");
                num3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Multiplication:{Multiplication(num2, num3)}");
                break;

            case 4:
                Console.WriteLine("Division");
                Console.Write("Enter the first number:");
                num2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the second number:");
                num3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Division:{Division(num2, num3)}");
                break;

            default:
                Console.WriteLine("Wrong Info");
                break;

        }
    }
}