namespace FinalBattle;

public class Party
{
    public IPlayer Player { get; }

    private readonly List<ICharacter> _characters = new();

    public Party()
    {
        Player = new ComputerPlayer();
    }

    public void TakeTurns()
    {
        foreach(var character in _characters)
        {
            Console.WriteLine($"It is {character.Name}'s turn...");
            IAction action = Player.ChooseAction();
            character.TakeTurn(action);
            Console.WriteLine();
        }
    }

    public void Add(ICharacter character)
    {
        _characters.Add(character);
    }
}
