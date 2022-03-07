/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает три числа от пользователя
 * и выводит информацию о том, какое число больше
 */

int number1st, number2nd, number3rd;

Console.Write("Input 1st number: ");
number1st = Convert.ToInt32(Console.ReadLine());

Console.Write("Input 2nd number: ");
number2nd = Convert.ToInt32(Console.ReadLine());

Console.Write("Input 3rd number: ");
number3rd = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

Console.Write("Numbers: " + number1st);
Console.Write(", " + number2nd);
Console.WriteLine(" and " + number3rd);

if (number1st == number2nd && number2nd == number3rd) {
    Console.WriteLine("All three numbers are equal");
} else {
    int maxNumber = number1st;

    if (number2nd > maxNumber) {
        maxNumber = number2nd;
    }

    if (number3rd > maxNumber) {
        maxNumber = number3rd;
    }

    Console.WriteLine("Max of numbers is " + maxNumber);
}

Console.WriteLine();
