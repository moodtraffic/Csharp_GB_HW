/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Cоздает массив из N-элементов, заполненный случайными вещественными числами
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

double[] RealNumbers = generateArrayOfReal(size);

if (debug) {
    // просто выведем массив
    for (int i = 0; i < RealNumbers.Length ; i++) {
        Console.WriteLine(RealNumbers[i]);
    }

    Console.WriteLine();
}

Console.WriteLine();


double[] generateArrayOfReal(int size)
{
    double[] realNumbers = new double[size];

    Random generator = new Random();

    for (int i = 0; i < size; i++) {
        realNumbers[i] = generator.NextDouble();
    }

    return realNumbers;
}
