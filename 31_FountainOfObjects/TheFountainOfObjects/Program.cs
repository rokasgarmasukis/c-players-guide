using System.Diagnostics.Tracing;

Console.Title = "The Fountain of Objects";

Game Game = new Game();
Game.Run();

class Game
{
    World World { get; set; }
    Player Player { get; set; }
    public Game()
    {
        Player = new Player();
    }
    public void WorldInit()
    {
        int size;
        while (true)
        {
            Console.Write("What size of the world (small, medium, big): ");
            string choice = Console.ReadLine();
            size = choice switch
            {
                "small" => 4,
                "medium" => 6,
                "big" => 8,
                _ => 0,
            };
            if (size == 0)
            {
                continue;
            }
            break;
        }
        World = new World(size);
    }

    public void Run()
    {
        WorldInit();

        while (true)
        {
            Console.WriteLine("-----------------------------------------------------");
            ShowPlayerCoordinates();
            World.ShowMessages(Player);
            RunNextAction();
            if (Player.Row == 0 && Player.Column == 0 && World.FountainOn)
            {
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
                Console.WriteLine("You win!");
                break;
            }
        }
    }

    public void ShowPlayerCoordinates()
    {
        Console.WriteLine($"You are in the room at (Row={Player.Row}, Column={Player.Column})");
    }

    public void RunNextAction()
    {
        Console.Write("What do you want to do? ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "move east":
                Player.Move(1, 0, World);
                break;
            case "move west":
                Player.Move(-1, 0, World);
                break;
            case "move north":
                Player.Move(0, 1, World);
                break;
            case "move south":
                Player.Move(0, -1, World);
                break;
            case "enable fountain":
                World.ToogleFountain(Player);
                break;
            default:
                break;
        }
    }
}


class Player
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Player()
    {
        Row = 0;
        Column = 0;
    }

    public void Move(int xDirection, int yDirection, World world)
    {
        if (yDirection == 1 && Row == world.Size) return;
        else if (yDirection == -1 && Row == 0) return;
        else if (xDirection == 1 && Column == world.Size) return;
        else if (xDirection == -1 && Column == 0) return;
        else
        {
            Row = Row + yDirection;
            Column = Column + xDirection;
        }
    }
}

class World
{
    public Room[,] Rooms;
    public bool FountainOn { get; set; }
    public int Size { get; set; }
    private int FountainColumn { get; set; }

    public World(int size)
    {
        Rooms = new Room[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Rooms[i, j] = new Room();
            }
        }

        Rooms[0, 0].Type = RoomType.Entrance;
        Rooms[0, size - 2].Type = RoomType.Fountain;
        FountainOn = false;
        Size = size;
        FountainColumn = size - 2;
    }

    public void ToogleFountain(Player player) { if (player.Row == 0 && player.Column == FountainColumn) FountainOn = !FountainOn; }

    public void ShowMessages(Player player)
    {
        if (player.Row == 0 && player.Column == 0 && !FountainOn) Console.WriteLine("You see light coming from the cavern entrance");
        if (player.Row == 0 && player.Column == FountainColumn && !FountainOn) Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
        if (player.Row == 0 && player.Column == FountainColumn && FountainOn) Console.WriteLine("You hear the rushing waters from the the Fountain of Objects. It has been reactivated!");
        //if (Player.Row == 0 && Player.Column == 0 && World.FountainOn) Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
    }
}

class Room
{
    public RoomType Type { get; set; }
    public Room()
    {
        Type = RoomType.Empty;
    }
}

public enum RoomType { Empty, Entrance, Fountain };