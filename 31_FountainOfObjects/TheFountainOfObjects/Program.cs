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
        World.GenerateSpecialRooms();
        while (true)
        {
            Console.WriteLine("-----------------------------------------------------");
            ShowPlayerCoordinates();
            WorldDrawer.DrawWorld(Player, World);
            World.ShowMessages(Player);
            RunNextAction();
            if (Player.Row == 0 && Player.Column == 0 && World.FountainOn)
            {
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
                Console.WriteLine("You win!");
                break;
            }
            if (World.IsLost(Player))
            {
                Console.WriteLine("You fell into the pit!. You lost!");
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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        string choice = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
        if (yDirection == 1 && Row == world.Size - 1) return;
        else if (yDirection == -1 && Row == 0) return;
        else if (xDirection == 1 && Column == world.Size - 1) return;
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
        FountainOn = false;
        Size = size;
    }

    public void ToogleFountain(Player player) { if (Rooms[player.Row, player.Column].Type == RoomType.Fountain) FountainOn = !FountainOn; }

    public void ShowMessages(Player player)
    {

        Room currentRoom = Rooms[player.Row, player.Column];
        if (currentRoom.Type == RoomType.Entrance && !FountainOn) Console.WriteLine("You see light coming from the cavern entrance");
        if (currentRoom.Type == RoomType.Fountain && !FountainOn) Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
        if (currentRoom.Type == RoomType.Fountain && FountainOn) Console.WriteLine("You hear the rushing waters from the the Fountain of Objects. It has been reactivated!");
        //if (Player.Row == 0 && Player.Column == 0 && World.FountainOn) Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");

        int row = player.Row;
        int column = player.Column;
        if ((IsValidRoom(row - 1, column) && Rooms[row - 1, column].Type == RoomType.Pit)
            || (IsValidRoom(row + 1, column) && Rooms[row + 1, column].Type == RoomType.Pit)
            || (IsValidRoom(row, column + 1) && Rooms[row, column + 1].Type == RoomType.Pit)
            || (IsValidRoom(row, column - 1) && Rooms[row, column - 1].Type == RoomType.Pit)
            || (IsValidRoom(row + 1, column + 1) && Rooms[row + 1, column + 1].Type == RoomType.Pit)
            || (IsValidRoom(row - 1, column + 1) && Rooms[row - 1, column + 1].Type == RoomType.Pit)
            || (IsValidRoom(row - 1, column - 1) && Rooms[row - 1, column - 1].Type == RoomType.Pit)
            || (IsValidRoom(row + 1, column - 1) && Rooms[row + 1, column - 1].Type == RoomType.Pit)) Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
    }

    public bool IsLost(Player player)
    {
        if (Rooms[player.Row, player.Column].Type == RoomType.Pit) return true;
        else return false;
    }

    public void GenerateSpecialRooms()
    {
        Random rand = new Random();
        int xFountain = rand.Next(2, 3);
        int yFountain = rand.Next(2, 3);
        Rooms[xFountain, yFountain].Type = RoomType.Fountain;

        int xPit;
        int yPit;
        do
        {
            xPit = rand.Next(1, 3);
            yPit = rand.Next(1, 3);
        } while (xPit == xFountain && yPit == yFountain);

        Rooms[xPit, yPit].Type = RoomType.Pit;


    }

    public bool IsValidRoom(int row, int column) =>
        row >= 0
        && row <= Size - 1
        && column >= 0
        && column <= Size - 1;
}

class WorldDrawer
{
    public static void DrawWorld(Player player, World world)
    {
        Console.WriteLine(new String('-', world.Size * 5));
        for (int i = world.Size - 1; i >= 0; i--)
        {
            Console.Write("|");
            for (int j = 0; j < world.Size; j++)
            {
                if (i == player.Row && j == player.Column)
                {
                    Console.Write(" x |");
                } else
                {
                    Console.Write("   |");
                }
            }
            Console.WriteLine();
            Console.WriteLine(new String('-', world.Size * 5 ));
        }
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

public enum RoomType { Empty, Entrance, Fountain, Pit, OffWorld };