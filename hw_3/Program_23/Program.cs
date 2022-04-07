/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает число N от пользователя,
 * выдает таблицу кубов от 1 до N
 * @todo сделать красивое форматирвоание таблицей
 */

int number = 0;
double numberCube = 0;
double rate = 3;

Console.Write($"Input a number: ");
number = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

if (number < 1) {
    Console.WriteLine($"Your number [{number}] is not too low]");
    Console.WriteLine("Exit");

    Environment.Exit(0);
}

Console.WriteLine($"N => N^{rate}");

for (int i = 1; i <= number; i++) {
    numberCube = Math.Pow(Convert.ToDouble(i), rate);

    Console.WriteLine($"{i} => {numberCube}");
}

Console.WriteLine();
