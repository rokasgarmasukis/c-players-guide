namespace FinalBattle;

public class ComputerPlayer : IPlayer
{
    public IAction ChooseAction() => new DoNothing();
}
