/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Программу, которая выведет все натуральные числа в промежутке от M до N в обратном порядке.
 * Пример: M = 1; N = 5. -> «5, 4, 3, 2, 1»
 */

int M, N; // инициализация для чисел

(M, N) = inputNumbers(args);

int[] naturalNumbers = getNaturalNumbersFromRange(M, N);

Console.WriteLine($"Two numbers given: {M} and {N}");
Console.WriteLine();

if (naturalNumbers.Length < 1) {
    Console.WriteLine($"The range [{M}; {N}] includes no natural (≥ 1) numbers");
    Environment.Exit(0);
}

reverseArray(ref naturalNumbers); // по условию задачи нужно вывести в обратном порядке - развернем массив

Console.WriteLine($"The range [{M}; {N}] includes {naturalNumbers.Length} natural (≥ 1) numbers");
Console.Write("output reversed: ");

printArray(naturalNumbers);

Console.WriteLine();

int[] getNaturalNumbersFromRange(int number1, int number2)
{
    // расположим числа по возрастанию
    if (number1 > number2) {
        (number1, number2) = (number2, number1);
    }

    // если второе число меньше 1 - то натуральных числе в промежутке нет
    if (number2 < 1) {
        return new int[0] {};
    }

    // числа меньше 1 - НЕ являются натуральными
    if (number1 < 1) {
        number1 = 1;
    }

    int size = number2 - number1 + 1; // кол-во натуральных чисел

    int[] numbers = new int[size];

    for (int i = 0; i < size; i++) {
        numbers[i] = number1 + i;
    }

    return numbers;
}

void printArray(in int[] Array, string delimiter = ", ")
{
    int last = Array.Length -1;

    for (int i = 0; i < last; i++) {
        Console.Write($"{Array[i]}{delimiter}");
    }

    Console.WriteLine($"{Array[last]}");
}

void reverseArray(ref int[] Array)
{
    int size = Array.Length;

    for (int i = 0; i < size / 2; i++) {
        (Array[i], Array[size -i -1]) = (Array[size -i -1], Array[i]);
    }
}

(int, int) inputNumbers(string[] args)
{
    int number1 = 0;
    int number2 = 0;

    if (args.Length > 0) {
        number1 = int.Parse(args[0]);
    } else {
        number1 = inputNumber("Input first number (M): ");
    }

    if (args.Length > 1) {
        number2 = int.Parse(args[1]);
    } else {
        number2 = inputNumber($"Input second number (N), it should be ≥ {number1}: ", number1);
    }

    return (number1, number2);
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
