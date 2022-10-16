Console.Title = "Hunting the Manticore";

int healthManticore = 10;
int maxHealthManticore = 10;
int healthCity = 15;
int maxHealthCity = 15;
int round = 1;

int distanceManticore = AskForNumberInRange("Player 1, how far away from the city do you want to station the Manticore? ", 0, 100);

Console.Clear();





int AskForNumber(string text)
{
    Console.WriteLine(text);
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