namespace FinalBattle;

public class Skeleton : ICharacter
{
    public string Name { get; } = "SKELETON";
    public void TakeTurn(IAction action)
    {
        action.Execute(Name);
    }
}
