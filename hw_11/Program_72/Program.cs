/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Заданы 2 массива: info и data. В массиве info хранятся двоичные представления нескольких чисел (без разделителя).
 * В массиве data хранится информация о количестве бит, которые занимают числа из массива info.
 * Напишите программу, которая составит массив десятичных представлений чисел массива data с учётом информации из массива info.
 */

 // int[] data = new int[9] {0, 1, 1, 1, 1, 0, 0, 0, 1, 0};
 // int[] info = new int[4] {2, 3, 3, 1}; // 2 7 0 1

int[] data = new int[10] {0, 0, 0, 0, 1, 1, 1, 1, 0, 1};
int[] info = new int[3] {5, 3, 2}; // 16 7 2

try {
    TuringMachine tape = new TuringMachine(data, info);

    Console.WriteLine("Reading tape...");
    Console.Write("|");

    foreach (int value in tape.getNextValue()) {
        Console.Write($" {value} |");
    }

    Console.WriteLine();
    Console.WriteLine("Done");
} catch (Exception e) {
    Console.WriteLine("Error: " + e.Message);
}

Console.WriteLine();

public class TuringMachine
{
    protected int[] bits;
    protected int[] sizes;

    public TuringMachine(int[] bits, int[] sizes)
    {
        this.bits = bits;
        this.sizes = sizes;

        this.validate();
    }

    public System.Collections.Generic.IEnumerable<int> getNextValue()
    {
        int index = 0;
        int offset = 0;

        for (int i = 0; i < this.sizes.Length; i++) {
            offset = this.sizes[i]; // кол-во бит

            yield return this.bitsToNumber(index, offset);

            index += offset; // смещаемся
        }
    }

    protected int bitsToNumber(int index, int offset)
    {
        int number = 0; // тут будет число
        int numberProduct = 1; // 2 в степени 0 = 1

        // Пример: 10101 = 2^0 * 1 + 2^1 * 0 + 2^2 * 1 + 2^3 * 0 + 2^4 * 1
        // собираем число по формуле, справа налево
        for (int i = index; i <= index + offset -1; i++) {
            if (1 == this.bits[i]) { // суммируем если бит = 1
                number += numberProduct;
            }

            numberProduct *= 2; // следующая степень для 2
        }

        return number;
    }

    protected void validate()
    {
        int countNumbers = 0;

        for (int i = 0; i < this.sizes.Length; i++) {
            countNumbers += this.sizes[i];
        }

        // битов должно быть не меньше чем сумма цифр, иначе битов не хватит
        if (countNumbers > this.bits.Length) {
            throw new Exception($"Number of bits should be ≥ {countNumbers}, but only {this.bits.Length} bits given");
        }
    }
}
