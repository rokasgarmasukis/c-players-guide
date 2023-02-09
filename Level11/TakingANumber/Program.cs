Console.Title = "Level 11 - Ask For a Number";


int AskForNumber(string text)
{
    Console.Write(text);
    int input = Convert.ToInt32(Console.ReadLine());
    return input;
}


int AskForNumberInRange(string text, int min, int max)
{
    int input;
    while (true)
    {
        Console.Write(text);
        input = Convert.ToInt32(Console.ReadLine());
        if (input > max || input < min) continue;
        break;
    }
    return input;
}

int answer = AskForNumber("give me some number: ");
Console.WriteLine($"Here is it: {answer}");

answer = AskForNumberInRange("give me some number between 5 and 10: ", 5, 10);
Console.WriteLine($"Here is it: {answer}");