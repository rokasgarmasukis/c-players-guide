namespace FountainOfObjects;

public class Player
{
    public Location Location { get; set; }

    public Player()
    {
        Location = new Location();
    }
    public string GetInput()
    {
        Console.Write("What do you want to do? ");
        return Console.ReadLine();
    }
}
