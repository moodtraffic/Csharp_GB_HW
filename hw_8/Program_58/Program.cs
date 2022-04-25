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

fillMatrixWithRandomNumbers(ref matrix1, 0, 100);
fillMatrixWithRandomNumbers(ref matrix2, 0, 100);

// test2x2x2x2(ref matrix1, ref matrix2); => 2x2
// test2x2x2x3(ref matrix1, ref matrix2); => 2x3
// test3x1x1x3(ref matrix1, ref matrix2); => 3x3
// test1x3x3x1(ref matrix1, ref matrix2); => 1x1

Console.WriteLine("Matrix #1:");
printMatrix(matrix1);
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Matrix #2:");
printMatrix(matrix2);
Console.WriteLine();
Console.WriteLine();

int[,] matrixResult = new int[M1, N2]; // matrix1.rows1 x matrix2.cols

try {
    matrixResult = matrixMultiplication(matrix1, matrix2);

    Console.WriteLine("Result matrix:");
    printMatrix(matrixResult);
} catch (Exception e) {
    Console.WriteLine("Error: " + e.Message);
}

Console.WriteLine();

/******************** [ functions ] ****************************************/

int[,] matrixMultiplication(in int[,] matrix1, in int[,] matrix2)
{
    if (true != isMultiplicationPossible(matrix1, matrix2)) {
        throw new Exception($"It is not possible to make multiplication, matrix #1 has {N1} cols but matrix #2 has {M2} rows");
    }

    // строк в новой матрице, колонок в новой матрице, сллагаемых в каждой ячейке
    (int newRows, int newCols, int size) = (matrix1.GetLength(0), matrix2.GetLength(1), matrix1.GetLength(1));

    int[,] matrixNew = new int[newRows, newCols];

    int[] row = new int[size];
    int[] column = new int[size];

    for (int j = 0; j <  newCols; j++) { // cols of matrix2
        for (int i = 0; i < newRows; i++) { // rows of matrix1
            matrixNew[i, j] = 0; // initial

            row = matrixGetRow(matrix1, i); // row from matrix1
            column = matrixGetColumn(matrix2, j); // column from matrix2

            for (int k = 0; k < size; k++) {
                matrixNew[i, j] += row[k] * column[k];
            }
        }
    }

    return matrixNew;
}

bool isMultiplicationPossible(in int[,] matrix1, int[,] Array2)
{
    return (matrix1.GetLength(1) == matrix2.GetLength(0));
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

void test2x2x2x2(ref int[,] matrix1, ref int[,] matrix2)
{
    matrix1[0, 0] = 1;
    matrix1[0, 1] = 2;
    matrix1[1, 0] = 3;
    matrix1[1, 1] = 4;

    matrix2[0, 0] = 0;
    matrix2[0, 1] = 0;
    matrix2[1, 0] = 1;
    matrix2[1, 1] = 1;

    // result:
    // 0,0 = 2
    // 0,1 = 2
    // 1,0 = 4
    // 1,1 = 4
}

void test2x2x2x3(ref int[,] matrix1, ref int[,] matrix2)
{
    matrix1[0, 0] = 2;
    matrix1[0, 1] = 3;
    matrix1[1, 0] = 6;
    matrix1[1, 1] = 5;

    matrix2[0, 0] = 8;
    matrix2[0, 1] = 9;
    matrix2[0, 2] = 7;
    matrix2[1, 0] = 5;
    matrix2[1, 1] = 3;
    matrix2[1, 2] = 5;

    // result:
    // 0,0 = 31
    // 0,1 = 27
    // 0,2 = 29
    // 1,0 = 73
    // 1,1 = 69
    // 1,2 = 67
}
