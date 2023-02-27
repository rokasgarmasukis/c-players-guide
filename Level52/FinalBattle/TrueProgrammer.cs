namespace FinalBattle;

public class TrueProgrammer : ICharacter
{
    public string Name { get; }

    public void TakeTurn(IAction action)
    {
        action.Execute(Name);
    }

    public TrueProgrammer(string name)
    {
        Name = name;
    }
}
