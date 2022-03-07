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
    Console.WriteLine("Your number is zero");
} else if (number % 2 == 0) {
    Console.WriteLine("Your number " + number + " is even");
} else {
    Console.WriteLine("Your number " + number + " is odd");
}

Console.WriteLine();
