namespace FinalBattle;

public interface ICharacter
{
    string Name { get; }
    void TakeTurn(IAction action);
}
