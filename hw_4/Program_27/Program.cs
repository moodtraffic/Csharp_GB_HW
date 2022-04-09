/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает на вход целое число и выводит сумма его цифр
 */

int number = 0;

// введен ли первый аргумент? число A
if (args.Length >= 1) {
    number = int.Parse(args[0]);
}

if (number < 1) {
    Console.Write("Input unsigned number: ");
    number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
}

if (number < 1) {
    Console.WriteLine($"Number [{number}] is not too low");
    Console.WriteLine("Exit");

    Environment.Exit(0);
}

uint digitsCount = 0;
int digitsSumm = getSummDigitsOfNumber(number, ref digitsCount);

Console.WriteLine($"Number is {number}, it has {digitsCount} digits, and summ of digits is {digitsSumm}");
Console.WriteLine();

int getSummDigitsOfNumber(int number, ref uint digitsCount)
{
    int summ = 0;
    digitsCount = 0;

    while (number > 0) {
        summ += number % 10;
        number = number / 10;
        digitsCount++;
    }

    return summ;
}
