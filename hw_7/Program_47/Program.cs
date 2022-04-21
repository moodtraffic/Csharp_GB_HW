/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Пользователь вводит с клавиатуры размеры двумерного массива,
 * программа заполняет массив случайными вещественными числами.
 */

int M, N; // инициализация для чисел, размеров матрицы MxN

(M, N) = inputNumbers(args); // rows, cols

double[,] matrix = new double[M, N];

Console.WriteLine($"Matrix size is {M}x{N}");
Console.WriteLine();

fillMatrixWithRandomRealNumbers(ref matrix);

printMatrix(matrix);

Console.WriteLine();
Console.WriteLine();

/******************** [ functions ] ****************************************/

void fillMatrixWithRandomRealNumbers(ref double[,] Array, double multiplier = 10)
{
    Random generator = new Random();

    for (int i = 0; i < Array.GetLength(0); i++) {
        for (int j = 0; j < Array.GetLength(1); j++) {
            Array[i, j] = generator.NextDouble() * multiplier;
        }
    }
}

void printMatrix(in double[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++) {
        for (int j = 0; j < Array.GetLength(1); j++) {
            Console.Write($"{Array[i, j], 6:F2}");
        }

        Console.WriteLine();
    }
}

(int, int) inputNumbers(string[] args)
{
    int rows = 0;
    int cols = 0;

    if (args.Length > 0) {
        rows = int.Parse(args[0]);
    } else {
        rows = inputNumber("Input rows number (M), ≥ 1: ", 1);
    }

    if (args.Length > 1) {
        cols = int.Parse(args[1]);
    } else {
        cols = inputNumber($"Input cols number (N), ≥ 1: ", 1);
    }

    return (rows, cols);
}

int inputNumber(string message, int? MinValue = null, int? MaxValue = null)
{
    string? errorMessage = null;
    int number = 0;

    if (MinValue == null && MaxValue == null) {
        MinValue = Int32.MinValue;
        MaxValue = Int32.MaxValue;
    } else if (MinValue == null) {
        MinValue = Int32.MinValue;

        errorMessage = $"Number should be ≤ {MaxValue}";
    } else if (MaxValue == null) {
        MaxValue = Int32.MaxValue;

        errorMessage = $"Number should be ≥ {MinValue}";
    } else {
        errorMessage = $"Number should be in range [{MinValue}; {MaxValue}]";
    }

    do {
        Console.Write(message);

        if (int.TryParse(Console.ReadLine(), out number) && number >= MinValue && number <= MaxValue) {
            break;
        }

        if (null != errorMessage) {
            Console.WriteLine(errorMessage);
        }
    } while(true);

    return number;
}
