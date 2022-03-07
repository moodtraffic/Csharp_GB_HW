/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает два числа от пользователя
 * и выводит информацию о том, какое число больше
 */

int firstNumber;
int secondNumber;

Console.Write("Inpur first number: ");

firstNumber = Convert.ToInt32(Console.ReadLine());

Console.Write("Inpur second number: ");
secondNumber = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

if (firstNumber == secondNumber) {
    Console.WriteLine("Numbers are equal");
} else if (firstNumber > secondNumber) {
    Console.WriteLine("The first number is greater than second number");
} else {
    Console.WriteLine("The second number is greater than first number");
}

Console.WriteLine();
