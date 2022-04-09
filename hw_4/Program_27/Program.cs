/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает на вход натуральное число и выводит сумму его цифр
 */

const bool isOnlyNatural = true;

int number = 0;

// введен ли первый аргумент?
if (args.Length >= 1) {
    number = int.Parse(args[0]);
} else {
    Console.Write("Input a number: ");
    number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
}

if (isOnlyNatural && number < 1) {
    Console.WriteLine($"The number [{number}] shoud be ≥ 1");
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

    number = Math.Abs(number);

    while (number > 0) {
        summ += number % 10;
        number = number / 10;
        digitsCount++;
    }

    return summ;
}
