Console.Title = "The Point";

Point origin = new Point();
Point firstPoint = new Point(2, 3);
Point secondPoint = new Point(-4, 0);

Console.WriteLine($"({origin.X}, {origin.Y})");
Console.WriteLine($"({firstPoint.X}, {firstPoint.Y})");
Console.WriteLine($"({secondPoint.X}, {secondPoint.Y})");

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point() : this(0, 0) { }

}