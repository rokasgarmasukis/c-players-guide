namespace FinalBattle;

public class DoNothing : IAction
{
    public void Execute(string name)
    {
        Console.WriteLine($"{name} did NOTHING");
    }
}
