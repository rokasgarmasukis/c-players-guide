using FountainOfObjects;



Console.Title = "Fountain of Objects";

Game game = GetGame();
DateTime start = DateTime.Now;
game.Run();
DateTime end = DateTime.Now;
TimeSpan gameDuration = end - start;
Console.WriteLine($"The game lasted {gameDuration.Minutes}m {gameDuration.Seconds}s");

Game GetGame()
{
    Console.Write("What size of world: 4x4, 6x6, 8x8: ");
    string input = Console.ReadLine();
    Game game = input switch
    {
        "4x4" => CreateSmallGame(),
        "6x6" => CreateMediumGame(),
        "8x8" => CreateLargeGame(),
    };
    return game;
}

Game CreateSmallGame()
{
    Location fountain = new Location(0, 2);
    Location entrance = new Location();
    Map map = new Map(4, entrance, fountain);

    Player player= new Player();
    return new Game(player, map);
}

Game CreateMediumGame()
{
    Location fountain = new Location(1, 4);
    Location entrance = new Location();
    Map map = new Map(6, entrance, fountain);

    Player player = new Player();
    return new Game(player, map);
}

Game CreateLargeGame()
{
    Location fountain = new Location(2, 6);
    Location entrance = new Location();
    Map map = new Map(8, entrance, fountain);

    Player player = new Player();
    return new Game(player, map);
}