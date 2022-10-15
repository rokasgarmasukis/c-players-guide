Console.Title = "The Magic Cannon";

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;

for (int i = 1; i <= 100; i++)
{
    if (i % 5 == 0 && i % 3 == 0)
    {
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"{i}: Combined");
    } else if (i % 5 == 0)
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"{i}: Electric");
    } else if (i % 3 == 0)
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{i}: Fire");
    } else
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine($"{i}: Normal");
    }
}