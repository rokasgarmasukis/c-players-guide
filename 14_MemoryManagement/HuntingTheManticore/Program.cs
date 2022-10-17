using System.Diagnostics.SymbolStore;

Console.Title = "Hunting the Manticore";

int healthManticore = 10;
int maxHealthManticore = 10;
int healthCity = 15;
int maxHealthCity = 15;
int round = 1;

int distanceManticore = AskForNumberInRange("Player 1, how far away from the city do you want to station the Manticore? ", 0, 100);

bool isWinner = false;

Console.Clear();
Console.WriteLine("Player 2, it is your turn.");

while (!isWinner)
{
    PrintStatusMessage(round, healthCity, maxHealthCity, healthManticore, maxHealthManticore);
    int expectedDamage = CalculateExpectedDamage(round);
    PrintExpectedDamageMessage(expectedDamage);

    int cannonRange = AskForNumberInRange("Enter desired cannon range: ", 0, 100);
    PrintDamageMessage(distanceManticore, cannonRange);

    if (wasManticoreHit(distanceManticore, cannonRange)) healthManticore -= expectedDamage;
    
    isWinner = IsWinner(healthCity, healthManticore);
    healthCity--;

    round++;   
}

PrintWinnerMessage(healthCity);

// --------------------- METHODS -----------------------

void PrintWinnerMessage(int healthCity)
{
    if (healthCity > 0) Console.WriteLine("The Manticore has destroyed the city!");
    else Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
}

bool IsWinner(int healthCity, int healthManticore)
{
    if (healthManticore <= 0 || healthCity <= 0) return true;
    else return false;
}

void PrintStatusMessage(int round, int healthCity, int maxHealthCity, int healthManticore, int maxHealthManticore)
{
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine($"STATUS: Round: {round}\tCity: {healthCity}/{maxHealthCity}\tManticore: {healthManticore}/{maxHealthManticore}");
}

void PrintExpectedDamageMessage(int expectedDamage)
{
    Console.WriteLine($"The cannon is expected to deal {expectedDamage} damage this round.");
}

void PrintDamageMessage(int distanceManticore, int cannonRange)
{
    if (distanceManticore < cannonRange) Console.WriteLine("That round OVERSHOT the target");
    else if (distanceManticore > cannonRange) Console.WriteLine("That round FELL SHORT of the target");
    else Console.WriteLine("That round was a DIRECT HIT");
}

bool wasManticoreHit(int distanceManticore, int cannonRange)
{
    if (distanceManticore > cannonRange || distanceManticore < cannonRange) return false;
    else return true;
}

int CalculateExpectedDamage(int roundNumber)
{
    if (roundNumber % 5 == 0 && roundNumber % 3 == 0) return 10;
    else if (roundNumber % 3 == 0 || roundNumber % 3 == 0) return 3;
    else return 1;
}

int AskForNumber(string text)
{
    Console.Write(text);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {
        int number = AskForNumber(text);
        if (number >= min && number <= max) return number;
    }
}