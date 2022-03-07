/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает два числа от пользователя
 * и выводит информацию о том, какое число больше
 */

int firstNumber;
int secondNumber;

Console.Write("Input first number: ");

firstNumber = Convert.ToInt32(Console.ReadLine());

Console.Write("Input second number: ");
secondNumber = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

if (firstNumber == secondNumber) {
    Console.WriteLine("Numbers are equal");
} else if (firstNumber > secondNumber) {
    Console.WriteLine("The first number " + firstNumber + " is greater than second number " + secondNumber);
} else {
    Console.WriteLine("The second number " + secondNumber + " is greater than first number " + firstNumber);
}

Console.WriteLine();
