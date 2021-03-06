/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Cоздает массив из N-элементов, заполненный случайными числами,
 * находит сумму элементов с нечетными индексами
 */

const bool debug = true;
int size = 0;

// проверим введено ли кол-во элементов в первом аргументе при вызове программы
if (args.Length > 0) {
    size = Int32.Parse(args[0]);
}

// если размер задан не верно - уточним у пользователя
if (size < 1) {
    Console.Write("Set array size: ");
    size = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
}

if (size < 1) {
    Console.WriteLine("Array size should be > 0");

    Environment.Exit(0);
}

int[] Numbers = generateArrayOf(size, -1000, 1000);
int summ = calcElementsSummWithOddIndexes(Numbers);

if (debug) {
    // просто выведем массив
    for (int i = 0; i < Numbers.Length ; i++) {
        Console.Write(Numbers[i]);
        Console.WriteLine(i % 2 == 1 ? $" <- index is {i}" : "");
    }

    Console.WriteLine();
}

Console.WriteLine($"Array of {Numbers.Length} numbers");
Console.WriteLine($"summ of all elements with odd indexes is {summ}");
Console.WriteLine();

int[] generateArrayOf(int size, int minNumber = Int32.MinValue, int maxNumber = Int32.MaxValue)
{
    int[] numbers = new int[size];

    Random generator = new Random();

    for (int i = 0; i < size; i++) {
        numbers[i] = generator.Next(minNumber, maxNumber);
    }

    return numbers;
}

int calcElementsSummWithOddIndexes(in int[] Numbers)
{
    int summ = 0;

    // первая нечетная позиция это i = 1, далее с шагом 2 т.к. нам сразу нужны только нечетные индексы = 1, 3, 5 ...
    for (int i = 1; i < Numbers.Length; i += 2) {
        summ += Numbers[i];
    }

    return summ;
}
