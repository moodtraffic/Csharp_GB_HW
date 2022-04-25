/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Пользователь вводит с клавиатуры размеры двух двумерных массивов,
 * программа заполняет массивы случайными целыми числами.
 * Затем программа находит произведение матриц, если это возможно
 */

int M1, N1, M2, N2; // инициализация для чисел, размеров матрицы MxN

(M1, N1, M2, N2) = inputNumbers(args); // rows, cols, rows, cols

int[,] matrix1 = new int[M1, N1];
int[,] matrix2 = new int[M2, N2];

Console.WriteLine($"Matrix #1 size is {M1}x{N1}");
Console.WriteLine($"Matrix #2 size is {M2}x{N2}");
Console.WriteLine();

if (true != isMultiplicationPossible(matrix1, matrix2)) {
    Console.WriteLine($"It is not possible to make multiplication, matrix #1 has {M1} rows but matrix #2 has {N2} cols");
    Console.WriteLine();
    Environment.Exit(0);
}

fillMatrixWithRandomNumbers(ref matrix1, 0, 100);
fillMatrixWithRandomNumbers(ref matrix2, 0, 100);

Console.WriteLine("Matrix #1:");
printMatrix(matrix1);
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Matrix #2:");
printMatrix(matrix2);
Console.WriteLine();
Console.WriteLine();

// multiplication
// print result

Console.WriteLine();

/******************** [ functions ] ****************************************/

bool isMultiplicationPossible(in int[,] Array1, int[,] Array2)
{
    (int rows1, int cols1) = (Array1.GetLength(0), Array1.GetLength(1));
    (int rows2, int cols2) = (Array2.GetLength(0), Array2.GetLength(1));

    return (rows1 == cols2);
}

void fillMatrixWithRandomNumbers(ref int[,] Array, int MinValue = Int32.MinValue, int MaxValue = Int32.MaxValue)
{
    Random generator = new Random();

    for (int i = 0; i < Array.GetLength(0); i++) {
        for (int j = 0; j < Array.GetLength(1); j++) {
            Array[i, j] = generator.Next(MinValue, MaxValue);
        }
    }
}

int arrayGetSum(in int[] Array)
{
    int summ = 0;
    int size = Array.Length;

    for (int i = 0; i < size; i++) {
        summ += Array[i];
    }

    return summ;
}

int[] matrixGetRow(in int[,] Array, int rowNum)
{
    int[] row = new int[Array.GetLength(1)];

    for (int j = 0; j < Array.GetLength(1); j++) {
        row[j] = Array[rowNum, j];
    }

    return row;
}

int[] matrixGetColumn(in int[,] Array, int colNum)
{
    int[] column = new int[Array.GetLength(0)];

    for (int i = 0; i < Array.GetLength(0); i++) {
        column[i] = Array[i, colNum];
    }

    return column;
}

void printMatrix(in int[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++) {
        for (int j = 0; j < Array.GetLength(1); j++) {
            Console.Write($"{Array[i, j], 8}");
        }

        Console.WriteLine();
    }
}

(int, int, int, int) inputNumbers(string[] args)
{
    int rows1 = 0;
    int cols1 = 0;
    int cols2 = 0;
    int rows2 = 0;

    if (args.Length > 0) {
        rows1 = int.Parse(args[0]);
    } else {
        rows1 = inputNumber("Input matrix #1 rows number (M), ≥ 1: ", 1);
    }

    if (args.Length > 1) {
        cols1 = int.Parse(args[1]);
    } else {
        cols1 = inputNumber($"Input matrix #1 cols number (N), ≥ 1: ", 1);
    }

    if (args.Length > 2) {
        rows2 = int.Parse(args[2]);
    } else {
        rows2 = inputNumber("Input matrix #2 rows number (M), ≥ 1: ", 1);
    }

    if (args.Length > 3) {
        cols2 = int.Parse(args[3]);
    } else {
        cols2 = inputNumber($"Input matrix #2 cols number (N), ≥ 1: ", 1);
    }

    return (rows1, cols1, rows2, cols2);
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
