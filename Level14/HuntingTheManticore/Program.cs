Console.Title = "Hunting the Manticore";

string player1 = "Player 1, how far away from the city do you want to station the Manticore? ";
int distanceManticore = GetNumberInRange(player1, 0, 100);

Console.Clear();

Console.WriteLine("Player 2, it's your turn");

int healthManticore = 10;
int healthCity = 15;
int round = 1;

bool gameFinished = false;
while (!gameFinished)
{
    
    int damage = ComputeDamage(round);
    PrintGameStats(round, healthManticore, healthCity, damage);
    int shotDistance = GetNumberInRange("Enter desired cannon range: ", 0, 100);
    PrintShotStatus(distanceManticore, shotDistance);
    if (shotDistance == distanceManticore) healthManticore -= damage;
    healthCity--;
    round++;
    gameFinished = CheckForWin(healthManticore, healthCity);
}


void PrintGameStats(int round, int healthManticore, int healthCity, int damage)
{
    Console.WriteLine("--------------------------------------------------------");
    Console.WriteLine($"STATUS: Round: {round}\tCity: {healthCity}/15\tManticore: {healthManticore}/10");
    Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");
}

void PrintShotStatus(int distanceManticore, int shotDistance)
{
    if (distanceManticore == shotDistance) Console.WriteLine("That round was a DIRECT HIT!");
    if (distanceManticore > shotDistance) Console.WriteLine("That round FELL SHORT of the target.");
    if (distanceManticore < shotDistance) Console.WriteLine("That round OVERSHOT the target.");
}

int ComputeDamage(int round)
{
    if (round % 5 == 0 && round % 3 == 0) return 10;
    else if (round % 5 == 0 || round % 3 == 0) return 3;
    return 1;
}


int GetNumberInRange(string text, int min, int max)
{
    
    while (true)
    {
        Console.Write(text);
        int number = Convert.ToInt32(Console.ReadLine());
        if (number > min && number < max) return number;
    }
}



bool CheckForWin(int healthManticore, int healthCity)
{
    if (healthManticore <= 0 && healthCity > 0)
    {
        Console.WriteLine(  "The Manticore has been destroyed! The city of Consolas has been saved!");
        return true;
    }
    else if (healthCity == 0)
    {
        Console.WriteLine("The city of Consolas has been destroyed!");
        return true;
    }
    return false;
}