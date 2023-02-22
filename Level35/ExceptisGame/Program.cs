Console.Title = "Excepti's Game";

List<int> usedNumbers = new List<int>();

Random random = new Random();
int gameNumber = random.Next(10);

while(true)
{
    Console.Write("Pick a number between 0 and 9: ");
    int input = Convert.ToInt32(Console.ReadLine());
    try
    {
        if (input == gameNumber) throw new ArgumentException("You cannot choose this number.");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
    if (usedNumbers.Contains(input)) continue;
    usedNumbers.Add(input);

}