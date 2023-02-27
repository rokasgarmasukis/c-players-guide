namespace FinalBattle;

public class TrueProgrammer : ICharacter
{
    public string Name { get; }

    public void TakeTurn()
    {
        Console.WriteLine($"{Name} did NOTHING");
    }

    public TrueProgrammer(string name)
    {
        Name = name;
    }
}
