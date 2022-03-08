/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает два числа от пользователя,
 * проверяет кратно ли первое число второму
 */

int number1st, number2nd;
int divReminder = 0;

Console.Write("Input first number: ");
number1st = Convert.ToInt16(Console.ReadLine());

Console.Write("Input second number: ");
number2nd = Convert.ToInt16(Console.ReadLine());

Console.WriteLine();

if (number2nd == 0) {
    // проверим если вдруг второе число равно 0
    Console.WriteLine("Division by 0 detected!");
} else {
    if (isMultiplierOf(number2nd, number1st, ref divReminder)) {
        Console.WriteLine($"Yes, number {number1st} is multiple of {number2nd}");
    } else {
        Console.WriteLine($"No, division {number1st} by {number2nd} has reminder {divReminder}");
    }
}

Console.WriteLine();

/**
 * Принимает два целых числа [multipler] и [number]
 * Возвращает true, если возможно целочисленное деление
 * в переменную [reminder] записывается результат деления и передается по ссылке
 */
bool isMultiplierOf(int multipler, int number, ref int reminder) {
    // вычислим остаток от деления и вернем результат сравнения с 0
    return 0 == (reminder = number % multipler);
}
