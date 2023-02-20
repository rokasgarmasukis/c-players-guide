namespace FountainOfObjects;

public class Room
{
    public RoomType Type { get; set; }

    public Room(RoomType type)
    {
        Type = type;
    }
}


public enum RoomType { Empty, Fountain, Entrance };