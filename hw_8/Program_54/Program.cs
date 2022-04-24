/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Пользователь вводит с клавиатуры размеры двумерного массива,
 * программа заполняет массив случайными целыми числами.
 * Затем на ходит элементы, у которых оба индекса - нечетные
 * и заменяет значение элемента на квадрат его значения.
 */

int M, N; // инициализация для чисел, размеров матрицы MxN

(M, N) = inputNumbers(args); // rows, cols

int[,] matrix = new int[M, N];

Console.WriteLine($"Matrix size is {M}x{N}");
Console.WriteLine();

fillMatrixWithRandomNumbers(ref matrix, 0, 100);

Console.WriteLine("Matrix before:");
printMatrix(matrix);
Console.WriteLine();

sortMatrixFromMaxToMin(ref matrix);

Console.WriteLine("Matrix after:");
printMatrix(matrix);
Console.WriteLine();
Console.WriteLine();

/******************** [ functions ] ****************************************/

/**
 * Пронумеруем каждый элемент в матрицы абсолютныим номером - слева направа, сверху вниз.
 * Таким обрзом элемент [0; 0] - первый, [0; 1] - второй, и т.д.
 * В матрице MxN - номер последнего элемента равен числе элементов в матрице.
 * Суть сортировки - искать за 1 цикл позиции минимального и максимального, и менять их с первым и последним.
 * Перед началом цикла смещать первый номер вправо на 1, а последний влево на 1, в итоге
 * после [MxN / 2] циклов матрица будет отсортирована.
 */
void sortMatrixFromMaxToMin (ref int[,] Array)
{
    (int rows, int cols) = (Array.GetLength(0), Array.GetLength(1));

    // задаем границы
    int first = 0;
    int last = rows * cols;

    int i, j; // rows, cols interators
    int minValue, maxValue;
    int minPos, maxPos; // min and max values

    // устанавливаем начальные значения
    (minPos, maxPos) = (first, last);

    (i, j) = getMatrixCoodrsByNumber(first, rows, cols);
    minValue = Array[i, j];
    (i, j) = getMatrixCoodrsByNumber(last, rows, cols);
    maxValue = Array[i, j];

    Console.WriteLine();

    while (true) {
        // выходим, если в промежутке меньше 2 чисел - нечего менять
        if (last == first) {
            break;
        } else if (last - first == 2) {
            if (maxValue < minValue) {
                matrixSwapTwoCellsByCellsNumbers(ref Array, minPos, maxPos);
            }

            break;
        }

        // листаем промежуток
        for (int k = first +1; k < last -1; k++) {
            (i, j) = getMatrixCoodrsByNumber(k, rows, cols);

            if (minValue > Array[i, j]) {
                minValue = Array[i, j];
                minPos = k;
            } else if (maxValue < Array[i, j]) {
                maxValue = Array[i, j];
                maxPos = k;
            }
        }

        Console.WriteLine();
        Console.WriteLine();

        matrixSwapTwoCellsByCellsNumbers(ref Array, first, maxPos);
        matrixSwapTwoCellsByCellsNumbers(ref Array, last, minPos);

        if (--last - ++first < 1) {
            break;
        }
    }
}

(int, int) getMatrixCoodrsByNumber(int k, int rows, int cols)
{
    int i, j;

    i = rows -1;
    j = cols -1;

    Console.WriteLine($"{k} => {i}, {j}");

    return (i, j);
}

void matrixSwapTwoCellsByCellsNumbers(ref int[,] Array, int leftPos, int rightPos)
{
    if (leftPos == rightPos) {
        return;
    }

    (int rows, int cols) = (Array.GetLength(0), Array.GetLength(1));

    (int il, int jl) = getMatrixCoodrsByNumber(leftPos, rows, cols);
    (int ir, int jr) = getMatrixCoodrsByNumber(rightPos, rows, cols);

    (Array[il, jl], Array[ir, jr]) = (Array[ir, jr], Array[il, jl]);
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

void printArray(in int[] Array, string delimiter = ", ")
{
    int last = Array.Length -1;

    Console.Write("(");
    for (int i = 0; i < last; i++) {
        Console.Write($"{Array[i]}{delimiter}");
    }

    Console.WriteLine($"{Array[last]})");
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
