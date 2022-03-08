/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает принимает число от пользователя
 * и выводит информацию - четное (even) число или нечетное (odd)
 */

int number;

Console.Write("Input a number: ");
number = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

if (0 == number) {
    // число равно 0
    Console.WriteLine("Your number is zero");
} else if (number % 2 == 0) {
    // остаток от деления на 2 равен 0 - со-но число четное
    Console.WriteLine("Your number " + number + " is even");
} else {
    // иначе - не четное
    Console.WriteLine("Your number " + number + " is odd");
}

Console.WriteLine();
