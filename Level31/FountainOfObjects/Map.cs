namespace FountainOfObjects;

public class Map
{
    public Room[,] Rooms { get; set; }
    public Location Fountain { get; init; }
    public Location Entrance { get; init; }
    public bool IsFountainOn { get; set; } = false;

    public Map(int roomSize, Location entrance, Location fountain)
    {
        Entrance = entrance;
        Fountain = fountain;

        Rooms = new Room[roomSize, roomSize];

        for (int i = 0; i < roomSize; i++)
        {
            for (int j = 0; j < roomSize; j++)
            {
                Rooms[i, j] = new Room(RoomType.Empty);
            }
        }

    }


}
