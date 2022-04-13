/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Пользователь вводит с клавиатуры или задает самостоятельно M чисел.
 * Посчитайте, сколько чисел больше 0 ввёл пользователь.
 */

int[] modes = {1, 2, 3, 0};
string[] menus = {
    "Load from file",
    "Input from keyboard",
    "Fill with random",
    "Exit"
};

Console.Clear();
printMenu();

int numberCount = 0;
int[] Numbers = new int[] {};

int mode = chooseMode();

/******************** [ main ] ****************************************/

switch (mode) {
    case 1:
        string filename = "./program_41.data";

        Console.WriteLine($"Reading from file [{filename}]...");

        Numbers = readNumbersFromFile(filename);
        numberCount = Numbers.Length;

        Console.WriteLine($"{numberCount} lines read from file");

        printArray(Numbers);
        Console.WriteLine();

        break;

    case 2:
        numberCount = inputNumber("Set array size: ", 2);

        Numbers = new int[numberCount];

        Console.WriteLine($"And now, please, input {numberCount} numbers, line by line");
        for (int i = 0; i < numberCount; i++) {
            Numbers[i] = inputNumber($"  number {i+1} of {numberCount}: ", -10000, 10000);
        }
        Console.WriteLine();

        break;

    case 3:
        numberCount = inputNumber("Set array size: ", 2, 1000);

        Numbers = generateArrayOf(numberCount, -10000, 10000);

        printArray(Numbers);
        Console.WriteLine();

        break;
}

string resultMessage = "No numbers given. Exit";

if (numberCount > 0) {
    int positiveumbers = calcNumbersGreaterThan(Numbers, 0);

    if (positiveumbers == 1) {
        resultMessage = "Only one positive number found";
    } else if (positiveumbers > 1) {
        resultMessage = $"{positiveumbers} positive numbers found";
    } else {
        resultMessage = "No positive numbers found";
    }
}

Console.WriteLine(resultMessage);
Console.WriteLine();
Environment.Exit(0);

/******************** [ functions ] ****************************************/

void printMenu()
{
    Console.WriteLine("=== Program menu");
    Console.WriteLine();
    for (int i = 0 ; i < modes.Length; i++) {
        Console.WriteLine($"{modes[i]} - {menus[i]}");
    }
    Console.WriteLine();
}

int chooseMode()
{
    int mode;

    do {
        mode = inputNumber("Choose an action: ");
    } while(!modes.Contains(mode));

    return mode;
}

int calcNumbersGreaterThan(in int[] Numbers, int greaterThanMe)
{
    int counter = 0;

    for (int i = 0; i < numberCount; i++) {
        if (Numbers[i] > greaterThanMe) {
            ++counter;
        }
    }

    return counter;
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

int[] generateArrayOf(int size, int MinValue = Int32.MinValue, int MaxValue = Int32.MaxValue)
{
    int[] numbers = new int[size];

    Random generator = new Random();

    for (int i = 0; i < size; i++) {
        numbers[i] = generator.Next(MinValue, MaxValue);
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

int[] readNumbersFromFile(string filename)
{
    string[] lines = File.ReadAllLines(filename);

    int[] numbers = new int[lines.Count()];

    int i = 0;
    foreach (string line in lines) {
        int.TryParse(line, out int parsedNumber);

        numbers[i++] = parsedNumber;
    }

    return numbers;
}
