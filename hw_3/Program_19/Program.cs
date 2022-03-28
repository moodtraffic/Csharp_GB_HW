/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает число N от пользователя,
 * проверяет что оно является полиндромом
 */

uint length = 5; // кол-во цифр в числе
int number;

Console.Write($"Input a {length}-digit number: ");
number = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

/**
 * проверим что введенное число содержит ${length} цифр
 */
double minNumber = Math.Pow(10, length - 1);
double maxNumber = Math.Pow(10, length) - 1;

if (number < minNumber || number > maxNumber) {
    Console.WriteLine($"Your number is not at range [{minNumber}; {maxNumber}]");
    Console.WriteLine("Exit");

    Environment.Exit(0);
}

if (isPalindrome(Convert.ToString(number))) {
    Console.WriteLine($"Yes, number [{number}] is palindrome");
} else {
    Console.WriteLine($"No, number [{number}] is palindrome");
}

Console.WriteLine();

bool isPalindrome(string stringLine)
{
    int length = stringLine.Length;
    int middleIndex = length / 2; // индекс цифры в середине - не важно четное число или нет - сравнивать будем с нахлестом

    if (length < 1) {
        return false;
    }

    char[] numberDigits = stringLine.ToCharArray();
    bool isPalindrome = true; // значение по-умоланию

    for (int i = 0; i <= middleIndex; i++) {
        isPalindrome = isPalindrome && (numberDigits[i] == numberDigits[length - 1 -  i]);
    }

    return isPalindrome;
}
