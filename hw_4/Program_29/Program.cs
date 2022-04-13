/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Создает массив из 8 элементов, заполняет случайными числами и выводит на экран
 */

uint size = 8;

int[] randArray = generateArrayOf(size, 0, 100);

printArray(randArray);
Console.WriteLine();

int[] generateArrayOf(uint size, int minNumber = Int32.MinValue, int maxNumber = Int32.MaxValue)
{
    int[] numbers = new int[size];

    Random generator = new Random();

    for (int i = 0; i < size; i++) {
        // numbers[i] = i +1;
        // numbers[i] = (i +1) * (i +1);
        numbers[i] = generator.Next(minNumber, maxNumber);
    }

    return numbers;
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
