Console.Title = "Countdown";

void Countdown(int number)
{
    Console.WriteLine(number);
    if (number == 1) return;
    else Countdown(number - 1);
}

Countdown(10);