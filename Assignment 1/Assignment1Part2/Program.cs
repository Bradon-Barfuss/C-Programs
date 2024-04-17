// See https://aka.ms/new-console-template for more information

class Assignment1Part2
{
    /// <summary>
    /// The Main Class
    /// </summary>
    static void Main()
    {
        int number1;
        int number2;
        int sum;
        Console.WriteLine("Enter your first number: ");
        number1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter your second number: ");
        number2 = int.Parse(Console.ReadLine());

        sum = number1 + number2;
        Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
        Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
        Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
        Console.WriteLine($"{number1} / {number2} = {number1 / number2}");
        Console.WriteLine($"{number1} % {number2} = {number1 % number2}");

        if(number1 > number2)
        {
            Console.WriteLine($"{number1} is not less than {number2}");
            Console.WriteLine($"{number1} is greater than {number2}");
            Console.WriteLine($"{number1} is not equal to {number2}");
        }
        else if (number1 < number2)
        {
            Console.WriteLine($"{number1} is less than {number2}");
            Console.WriteLine($"{number1} is not greater than {number2}");
            Console.WriteLine($"{number1} is not equal to {number2}");
        }
        if (number1 == number2)
        {
            Console.WriteLine($"{number1} is not less than {number2}");
            Console.WriteLine($"{number1} is not greater than {number2}");
            Console.WriteLine($"{number1} is equal to {number2}");
        }
    }
}