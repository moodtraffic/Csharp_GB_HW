/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает создает массив из N-элементв, состоящий из трехзначныех положительных чисел,
 * выводи количество четных чисел в массиве
 */

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
    Console.WriteLine("Arrat size should be > 0");

    Environment.Exit(0);
}

int[] Numbers = generateArrayOf(size, 100, 999);
int counter = calcEvenNumbers(Numbers, true);

Console.WriteLine($"Array of {Numbers.Length} numbers has {counter} even numbers");
Console.WriteLine();

int[] generateArrayOf(int size, int minNumber = Int32.MinValue, int maxNumber = Int32.MaxValue)
{
    int[] numbers = new int[size];

    Random generator = new Random();

    for(int i = 0; i < size; i++) {
        numbers[i] = generator.Next(minNumber, maxNumber);
    }

    return numbers;
}

int calcEvenNumbers(int[] numbers, bool debug = false)
{
    int counter = 0;

    for(int i = 0; i < size; i++) {
        if (numbers[i] % 2 == 0) {
            counter++;
        }

        if (debug) {
            Console.WriteLine(Numbers[i]);
        }
    }

    return counter;
}
