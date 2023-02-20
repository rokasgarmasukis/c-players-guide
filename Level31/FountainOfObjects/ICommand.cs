namespace FountainOfObjects;

public class DoNothingCommand : ICommand
{
    public void Execute(Game game) { }
}

public class FountainOnCommand : ICommand
{
    public void Execute(Game game) => game.Map.IsFountainOn = true;
}

public class MoveCommand : ICommand
{
    private Direction Direction { get; }
    public void Execute(Game game)
    {
        int mapSize = game.Map.Rooms.GetLength(1);
        if (game.Player.Location.Row + Direction.X > mapSize - 1) return;
        if (game.Player.Location.Row + Direction.X < 0) return;
        if (game.Player.Location.Column + Direction.Y > mapSize - 1) return;
        if (game.Player.Location.Column + Direction.Y < 0) return;
        game.Player.Location.Row += Direction.X;
        game.Player.Location.Column+= Direction.Y;
    }

    public MoveCommand(Direction direction)
    {
        Direction = direction;
    }
}


public interface ICommand
{
    public void Execute(Game game);
}
