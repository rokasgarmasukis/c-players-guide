Console.Title = "Taking a Number";

int AskForNumber(string text)
{
    Console.Write(text);
    return int.Parse(Console.ReadLine());
}

int AskForNumberInRange(string text, int min, int max)
{
    int numInRange;
    while (true)
    {
        Console.Write(text);
        numInRange = int.Parse(Console.ReadLine());
        if (numInRange < min || numInRange > max) continue;
        break;
    }
    return numInRange;
}

int someNumber = AskForNumberInRange("Gimme a number between 5 and 10: ", 5, 10);
Console.WriteLine(someNumber);