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

(double MinRealNumber, double MaxRealNumber) = getMinAndMaxFromArray(RealNumbers);

Console.WriteLine($"Array of {RealNumbers.Length} numbers");
Console.WriteLine($"    Min is {MinRealNumber}");
Console.WriteLine($"    Max is {MaxRealNumber}");
Console.WriteLine($"Max minus Min is {MaxRealNumber-MinRealNumber}");
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

(double, double) getMinAndMaxFromArray(double[] RealNumbers)
{
    double MinValue = RealNumbers[0];
    double MaxValue = RealNumbers[0];

    for (int i = 1; i < RealNumbers.Length; i++) {
        if (MaxValue < RealNumbers[i]) {
            MaxValue = RealNumbers[i];
        }

        if (MinValue > RealNumbers[i]) {
            MinValue = RealNumbers[i];
        }
    }

    return (MinValue, MaxValue);
}
