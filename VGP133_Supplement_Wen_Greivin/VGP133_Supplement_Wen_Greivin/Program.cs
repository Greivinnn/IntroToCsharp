// See https://aka.ms/new-console-template for more information

Console.WriteLine("I am thinking of a number from 1 to 100...");
Console.WriteLine("Try guessing the number, I will give you 10 attempts.");

Random random = new Random();
int randomNumber = random.Next(1, 101);

int attemptNum = 1;
int maxAttempts = 10;

while (true)
{
    Console.WriteLine("Attempt number: " + attemptNum);

    string input = Console.ReadLine();
    int userGuess;

    if (!int.TryParse(input, out userGuess))
    {
        Console.WriteLine("Invalid input! Please enter a valid number between 1 and 100.");
        continue; // Skip this iteration and try again
    }

    if (userGuess > 100 || userGuess < 0)
    {
        Console.WriteLine("The number has to be within the range I am thinking of. 1 to 100 RAWR!");
        continue;
    }

    if (userGuess > randomNumber)
    {
        Console.WriteLine("Too high, the number is TOO HIGH");
    }

    if (userGuess < randomNumber)
    {
        Console.WriteLine("Too low, the number is WAY TOOO LOW");
    }

    if (userGuess == randomNumber)
    {
        Console.WriteLine("WOOOW, how did you read my mind like that...");
        Console.WriteLine("YOU HAVE WON, CONGRATS NOW GET OUTTA HERE");
        break;
    }

    if (attemptNum == maxAttempts)
    {
        Console.WriteLine("\nSTOP THERE! OUT OF ATTEMPTS. nice try *eveil laught*");
        Console.WriteLine($"The right number was: {randomNumber}");
        break;
    }

    attemptNum++;
}