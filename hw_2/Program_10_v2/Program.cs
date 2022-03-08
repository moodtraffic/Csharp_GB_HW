/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает число N от пользователя,
 * проверяет что оно трехзначеное и выводит вторую цифру этого числа
 *
 * Способ второй - регулярное выражение, и вывод по индексу
 */

using System;
using System.Text.RegularExpressions;

string number;
Regex re = new Regex(@"^(\d{3})$"); // регулярное выражение
// строка должжна строго начинаться с последовательности из цифр
// последовательность цифр должна быть длинной = 3
// строка дожна заканчиваться сразу после цифры
// создадим регулярное выражение

Console.Write("Input a number: ");
number = Console.ReadLine();

// поиск по регулярному выражению
MatchCollection matches = re.Matches(number);

Console.WriteLine();

if (matches.Count != 1) {
    // должно быть ровно одно совпадение, иначе строка нам не подходит
    Console.WriteLine("Input string does not matches [\\d{3}]");
} else {
    Console.WriteLine("Second digit of number " + number + " is " + getCharByIndex(number, 1));
}

Console.WriteLine();

/**
 * Превращает строку в массив символов и возвращает символ с позицией index
 */
char getCharByIndex(string input, int index = 0)
{
    char[] chars = input.ToCharArray(0, 3);

    return chars[index];
}
