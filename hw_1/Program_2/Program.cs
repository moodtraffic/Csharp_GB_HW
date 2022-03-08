/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает два числа от пользователя
 * и выводит информацию о том, какое число больше
 */

// сразу определим все переменные
int firstNumber, secondNumber;

Console.Write("Input first number: ");
firstNumber = Convert.ToInt32(Console.ReadLine());

Console.Write("Input second number: ");
secondNumber = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

if (firstNumber == secondNumber) {
    // если числа равны
    Console.WriteLine("Numbers are equal");
} else if (firstNumber > secondNumber) {
    // если первое больше
    Console.WriteLine("The first number " + firstNumber + " is greater than second number " + secondNumber);
} else {
    // иначе
    Console.WriteLine("The second number " + secondNumber + " is greater than first number " + firstNumber);
}

Console.WriteLine();
