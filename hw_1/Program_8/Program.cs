/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает число N от пользователя
 * и выводит все четные нормера на отрезке [2; N]
 */

// сразу определим все переменные
int number, iter;

Console.Write("Input a number: ");
number = Convert.ToInt32(Console.ReadLine());

iter = 2; // начнем сразу с 2, т.к. это наименшее положителньое четное число

Console.WriteLine();

if (number >= iter) {
    // введенное число больше или равно 2 / началу отрезка
    Console.WriteLine("Even numbers, which <= " + number + ": ");

    while (iter <= number) {
        // пока итератор не больше введенного числа
        Console.Write(iter + " ");

        iter += 2; // переходим к следующему четному числу
    }

    Console.WriteLine();
} else {
    // выведем сообщение, что число меньше 2
    Console.WriteLine("Your number " + number + " is less than 2.");
}

Console.WriteLine();
