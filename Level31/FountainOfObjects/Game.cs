namespace FountainOfObjects;

public class Game
{
    public Map Map { get; }

    public Player Player { get; }

    public Game(Player player, Map map)
    {
        Map = map;
        Player = player;
    }

    private void DisplayLocation()
    {
        Console.WriteLine($"You are in the room at (Row={Player.Location.Row}, Column={Player.Location.Column})");
    }

    public void Run()
    {
        while (!GameFinished())
        {
            DisplayLocation();
            ShowHints();
            MakeMove();
        }
    }

    private void MakeMove()
    {
        string input = Player.GetInput();
        ICommand command = input switch
        {
            "move east" => new MoveCommand(new Direction(0, 1)),
            "move west" => new MoveCommand(new Direction(0, -1)),
            "move south" => new MoveCommand(new Direction(-1, 0)),
            "move north" => new MoveCommand(new Direction(1, 0)),
            "enable fountain" => new FountainOnCommand(),
            _ => new DoNothingCommand(),
        };
        command.Execute(this);
    }

    private bool GameFinished()
    {
        if (Player.Location.Row == 0 && Player.Location.Column == 0 && Map.IsFountainOn)
        {
            DisplayLocation();
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
            Console.WriteLine("You win!");
            return true;
        }
        return false;
    }

    private void ShowHints()
    {
        // Fountain hints
        int rowDiffFountain = Math.Abs(Player.Location.Row - Map.Fountain.Row);
        int columnDiffFountain = Math.Abs(Player.Location.Column - Map.Fountain.Column);

        if (rowDiffFountain == 0 && columnDiffFountain == 0 && !Map.IsFountainOn)
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
        if (rowDiffFountain == 0 && columnDiffFountain == 0 && Map.IsFountainOn)
            Console.WriteLine("You here the rushing waters from the Fountain of Objects. It has been reactivated!");

        int rowDiffEntrance = Math.Abs(Player.Location.Row - Map.Entrance.Row);
        int columnDiffEntrance = Math.Abs(Player.Location.Column - Map.Entrance.Column);

        if (rowDiffEntrance == 0 && columnDiffEntrance == 0 && !Map.IsFountainOn)
            Console.WriteLine("You see light coming from the cavern entrance.");
    }

}

