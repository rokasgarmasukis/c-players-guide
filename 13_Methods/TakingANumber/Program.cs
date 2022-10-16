Console.Title = "Taking a Number";

int AskForNumber(string text)
{
    Console.WriteLine(text);
    int answer = Convert.ToInt32(Console.ReadLine());
    return answer;
}

int AskForNumberInRange(string text, int min, int max)
{
    int number;
    do
    {
        number = AskForNumber(text);
    }
    while (number < min || number > max);
    return number;
}