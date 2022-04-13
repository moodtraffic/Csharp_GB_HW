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

printMenu();
int mode = chooseMode();

int numberCount = 0;

switch (mode) {
    case 1:
        // read file
        // fill array from file
        break;

    case 2:
        numberCount = inputNumber("Set array size: ", 1);
        // запросить с клавиатуры
        break;

    case 3:
        numberCount = inputNumber("Set array size: ", 1);
        // сгенерировать массив
        break;
}

if (numberCount < 1) {
    Console.WriteLine();
    Environment.Exit(0);
}

// посчитать сколько числе больше 0

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
        errorMessage = $"Number should be betwean {MinValue} and {MaxValue}";
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
