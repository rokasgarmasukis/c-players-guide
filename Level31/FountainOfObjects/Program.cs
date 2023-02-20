using FountainOfObjects;

Console.Title = "Fountain of Objects";

Game game = CreateSmallGame();
game.Run();



Game CreateSmallGame()
{
    Location fountain = new Location(0, 2);
    Location entrance = new Location();
    Map map = new Map(4, entrance, fountain);

    Player player= new Player();
    return new Game(player, map);
}