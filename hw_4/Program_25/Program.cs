/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает на вход целое число A и целое число B. Выводит результат возведения
 * числа A в степень B.
 */

const bool isOnlyNatural = false;

int numberA = 0;
int numberB = 0;

// введен ли первый аргумент? число A
if (args.Length >= 1) {
    numberA = int.Parse(args[0]);
} else {
    Console.Write("Input number A: ");
    numberA = Convert.ToInt32(Console.ReadLine());
}

// введен ли второй агрумент? число B
if (args.Length >= 2) {
    numberB = int.Parse(args[1]);
} else {
   Console.Write("Input number B: ");
   numberB = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine();
}

if (isOnlyNatural && numberB < 1) {
    Console.WriteLine("Number B should be ≥ 1");
    Console.WriteLine("Exit");

    Environment.Exit(0);
}

// сделал общее решения не только для натуральных, но и для всех целых чисел

double Result = 1; // степень 0

if (numberB > 1) {
    for (int i = 0; i < numberB; i++) {
        Result *= numberA;
    }
} else if (numberB < 0) {
    for (int i = numberB; i < 0; i++) {
        Result = Result / numberA;
    }
} else if (numberB == 1) {
    Result = numberA;
}

Console.WriteLine($"A = {numberA} and B = {numberB}");
Console.WriteLine($"A^B = {Result}");
Console.WriteLine();
