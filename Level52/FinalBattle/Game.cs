namespace FinalBattle;

public class Game
{
    public Party Heroes;
    public Party Monsters;

    public Game()
    {
        Heroes = new Party();
        Monsters = new Party();
    }

    public void Run()
    {
        Console.Write("Hero's name: ");
        string name = Console.ReadLine();
        Heroes.Add(new TrueProgrammer(name ?? "Tug"));
        Monsters.Add(new Skeleton());

        while(true)
        {
            Heroes.TakeTurns();
            Thread.Sleep(1000);
            Monsters.TakeTurns();
            Thread.Sleep(1000);
        }
    }
}
