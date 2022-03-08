/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает число N от пользователя,
 * проверяет что оно трехзначеное и выводит вторую цифру этого числа
 *
 * Способ первый - делением
 */

int number;
int digit;

Console.Write("Input a number: ");
number = Convert.ToInt32(Console.ReadLine());

if (number < 100 || number > 999) {
    Console.WriteLine("Your number is not at range [100; 999]");
} else {
    /**
        варинант 1
        - найдем остаток от деления на 100 (987 -> 87)
        - найдем остаток от деления на 10 (987 -> 7)
        - вычтем второй из первого (87 -> 80)
        - разделим на 10
     */
    digit = (number % 100 - number % 10) / 10;

    /**
        вариант 2
        - найдем остаток от деления на 10  (987 -> 7)
        - вычтем из начального числа  (987 -> 980)
        - разделим на 10 (980 -> 98)
        - найдем остаток от деления на 10
     */
    // digit = (number - (number % 10) / 10) % 10;

    Console.WriteLine("Second digit of number " + number + " is " + digit);
}

Console.WriteLine();
