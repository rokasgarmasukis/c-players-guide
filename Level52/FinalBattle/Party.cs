namespace FinalBattle;

public class Party
{
    private readonly List<ICharacter> _characters = new();

    public void TakeTurns()
    {
        foreach(var character in _characters)
        {
            Console.WriteLine($"It is {character.Name}'s turn...");
            character.TakeTurn();
            Console.WriteLine();
        }
    }

    public void Add(ICharacter character)
    {
        _characters.Add(character);
    }
}
