/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Пользователь вводит с клавиатуры или задает самостоятельно M чисел.
 * Посчитайте, сколько чисел больше 0 ввёл пользователь.
 */

int mode;

int[] modes = {1, 2, 3, 0};
string[] menus = {
    "Load from file",
    "Input from keyboard",
    "Fill with random",
    "Exit"
};

printMenu();
chooseMode();

/******************** [ functions ] ****************************************/

// узнать кол-во числел у полльзователя

// сгенерировать массив

// запросить с клавиатуры

// посчитать сколько числе больше 0

void printMenu()
{
    Console.WriteLine("=== Program menu");
    Console.WriteLine();
    for (int i = 0 ; i < modes.Length; i++) {
        Console.WriteLine($"{modes[i]} - {menus[i]}");
    }
    Console.WriteLine();
}

void chooseMode()
{
    do {
        Console.Write("Choose an action: ");

        if (int.TryParse(Console.ReadLine(), out mode) && modes.Contains(mode)) {
            break;
        }
    } while(true);
}
