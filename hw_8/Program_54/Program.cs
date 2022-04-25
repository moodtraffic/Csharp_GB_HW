/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Пользователь вводит с клавиатуры размеры двумерного массива,
 * программа заполняет массив случайными целыми числами.
 * Затем программа сортировует мартрицу по убыванию значений в каждой строке,
 * в пределах всего массива
 */

bool debug = false;

int M, N; // инициализация для чисел, размеров матрицы MxN

(M, N) = inputNumbers(args); // rows, cols

int[,] matrix = new int[M, N];
// int counter = 1000; do { // for auto test
int swaps = 0;
Console.WriteLine($"Matrix size is {M}x{N}");
Console.WriteLine();
fillMatrixWithRandomNumbers(ref matrix, 0, 1000);

Console.WriteLine("Matrix before:");
printMatrix(matrix);
Console.WriteLine();

sortMatrixFromMaxToMin(ref matrix, ref swaps);

Console.WriteLine("Matrix after:");
printMatrix(matrix);
Console.WriteLine();

try {
    validateMatrixIsMaxToMin(in matrix);

    Console.WriteLine($"Matrix sorted with {swaps} swaps");
} catch (Exception e) {
    Console.WriteLine("Error: " + e.Message);
    // break; // for autotest
}

Console.WriteLine();
// } while(counter-- > 0); // for autotest
/******************** [ functions ] ****************************************/

void validateMatrixIsMaxToMin(in int[,] Array)
{
    int LastValue = Array[0, 0];

    for (int i = 0; i < Array.GetLength(0); i++) {
        for (int j = 0; j < Array.GetLength(1); j++) {
            if (LastValue < Array[i, j]) {
                throw new Exception($"Array was not sort good {LastValue} < {Array[i, j]} at [{i}; {j}]");
            }

            LastValue = Array[i, j];
        }
    }
}

/**
 * Пронумеруем каждый элемент в матрицы абсолютныим номером - слева направо, сверху вниз.
 * Таким обрзом элемент [0; 0] - первый, [0; 1] - второй, и т.д.
 * В матрице MxN - номер последнего элемента равен числе элементов в матрице.
 * Суть сортировки - искать за 1 цикл позиции минимального и максимального, и менять их с первым и последним.
 * Перед началом цикла смещать первый номер вправо на 1, а последний влево на 1, в итоге
 * после [MxN / 2] циклов матрица будет отсортирована.
 */
void sortMatrixFromMaxToMin (ref int[,] Array, ref int swaps)
{
    (int rows, int cols) = (Array.GetLength(0), Array.GetLength(1));

    // задаем границы
    int first = 1;
    int last = rows * cols;

    int i, j; // rows, cols interators
    int leftValue, rightValue;
    int minPos, maxPos;

    int cycle = 1;

    while (true) {
        if (debug) {
            Console.WriteLine($"---[ cycle #{cycle++, 2} ]---------------------------------------");
        }

        // устанавливаем начальные значения для первого (левого) и последнего (правого)
        (i, j) = getMatrixCoodrsByNumber(first, cols);
        leftValue = Array[i, j];
        (i, j) = getMatrixCoodrsByNumber(last, cols);
        rightValue = Array[i, j];

        (maxPos, minPos) = (first, last);

        if (leftValue < rightValue) {
            swaps += matrixSwapTwoCellsByCellsNumbers(ref Array, first, last, "<>");
            (leftValue, rightValue) = (rightValue, leftValue);
        }

        // листаем промежуток
        for (int k = first +1; k <= last -1; k++) {
            (i, j) = getMatrixCoodrsByNumber(k, cols);

            if (leftValue < Array[i, j]) {
                leftValue = Array[i, j];
                maxPos = k;
            } if (rightValue > Array[i, j]) {
                rightValue = Array[i, j];
                minPos = k;
            }
        }

        // Console.WriteLine($"{first} <=> {maxPos}");
        // Console.WriteLine($"{minPos} <=> {last}");

        swaps += matrixSwapTwoCellsByCellsNumbers(ref Array, first, maxPos, "<<");
        swaps += matrixSwapTwoCellsByCellsNumbers(ref Array, minPos, last, ">>");

        if (--last - ++first -1 < 0) {
            break; // выходим, если промежуток кончился
        }
    }
}

(int, int) getMatrixCoodrsByNumber(int k, int cols)
{
    return ((k -1) / cols, (k -1) % cols);
}

int matrixSwapTwoCellsByCellsNumbers(ref int[,] Array, int leftPos, int rightPos, string type)
{
    if (leftPos == rightPos) {
        return 0;
    }

    int cols = Array.GetLength(1);

    (int il, int jl) = getMatrixCoodrsByNumber(leftPos, cols);
    (int ir, int jr) = getMatrixCoodrsByNumber(rightPos, cols);

    (Array[il, jl], Array[ir, jr]) = (Array[ir, jr], Array[il, jl]);

    if (debug) {
        Console.WriteLine("  " + type);
        Console.WriteLine($"  {Array[il, jl]} <=> {Array[ir, jr]}");
        Console.WriteLine("Matrix after swap:");
        printMatrix(matrix);
        Console.WriteLine();
    }

    return 1;
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

void printMatrix(in int[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++) {
        for (int j = 0; j < Array.GetLength(1); j++) {
            Console.Write($"{Array[i, j], 8}");
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
