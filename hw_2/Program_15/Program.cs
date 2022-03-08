/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает число от пользователя,
 * проверяет кратно ли оно одновременно 7 и 23
 */

int number;
int divReminder = 0;

int[] multiplers = {7, 23}; // укажем список потенциальных множителей

Console.Write("Input first number: ");
number = Convert.ToInt16(Console.ReadLine());

Console.WriteLine();

// проверим каждый множитель
foreach (int multipler in multiplers) {
    Console.Write($"Is {number} multiple of {multipler}? ");
    Console.WriteLine(isMultiplierOf(multipler, number, ref divReminder) ? "Yes" : "No");
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
