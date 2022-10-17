/*
Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
M = 1; N = 15 -> 120
M = 4; N = 8. -> 30
*/

int M = 0, N = 0, sum = 0;

if (!InputControl())
    return;

DoWork(M);

Console.WriteLine($"M = {M}; N = {N} -> {sum}");

# region methods

bool InputControl()
{
    int tryCount = 3;
    string inputStr;
    bool resultInputCheck = false;

    while (!resultInputCheck)
    {
        Console.WriteLine($"\r\nЗадайте натуральные числа M и N (M < N) (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        string[] inputNumbers = inputStr.Split(new char[] { ' ', ';' });

        resultInputCheck = inputNumbers.Length == 2 && int.TryParse(inputNumbers[0], out M) && int.TryParse(inputNumbers[1], out N) && M >= 0 && N > 0 && M < N ;

        if (!resultInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

void DoWork(int number)
{
    if (number > N)
        return;

    sum += number;
    
    DoWork(++number);
}

#endregion
