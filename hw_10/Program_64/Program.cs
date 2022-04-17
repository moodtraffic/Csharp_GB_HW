/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Программу, которая выведет все натуральные числа в промежутке от M до N в обратном порядке.
 * Пример: M = 1; N = 5. -> «5, 4, 3, 2, 1»
 */

int M = -1;
int N = 15;

int[] naturalNumbers = getNaturalNumbersFromRange(M, N);

Console.WriteLine($"Two numbers given: {M} and {N}");
Console.WriteLine();

if (naturalNumbers.Length < 1) {
    Console.WriteLine($"The range [{M}; {N}] includes no natural (≥ 1) numbers");
    Environment.Exit(0);
}

Console.WriteLine($"The range [{M}; {N}] includes {naturalNumbers.Length} natural (≥ 1) numbers:");
printArray(naturalNumbers);

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
