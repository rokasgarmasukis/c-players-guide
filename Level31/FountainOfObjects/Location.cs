namespace FountainOfObjects;

public class Location
{
    public int Row { get; set; } = 0;
    public int Column { get; set; } = 0;

    public Location() : this(0, 0) { }

    public Location (int row, int column)
    {
        Row = row;
        Column = column;
    }
}
