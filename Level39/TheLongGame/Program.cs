Console.Title = "The Long Game";

Console.Write("What's your name? ");
string name = Console.ReadLine() ?? "Unknown";
string fileName = $"{name}.txt";

int playerScore;
if (File.Exists(fileName))
    playerScore = Convert.ToInt32(File.ReadAllText(fileName));
else
    playerScore = 0;

while (true)
{
    ConsoleKey key = Console.ReadKey().Key;
    if (key == ConsoleKey.Enter)
        break;

    playerScore++;
    Console.WriteLine($"Your score: {playerScore}");
}
File.WriteAllText(fileName, $"{playerScore}");
