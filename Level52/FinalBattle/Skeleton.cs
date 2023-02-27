namespace FinalBattle;

public class Skeleton : ICharacter
{
    public string Name { get; } = "SKELETON";
    public void TakeTurn()
    {
        Console.WriteLine("SKELETON did NOTHING.");
    }
}
