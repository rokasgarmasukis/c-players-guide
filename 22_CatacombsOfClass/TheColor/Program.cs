Console.Title = "The Color";

Color purple = Color.Purple;
Color random = new Color(56, 199, 24);

Console.WriteLine($"Color: {purple.ToString()}, R: {purple.RedChannel}, G: {purple.GreenChannel}, B: {purple.BlueChannel}");
Console.WriteLine($"Color: {random.ToString()}, R: {purple.RedChannel}, G: {purple.GreenChannel}, B: {purple.BlueChannel}");

public class Color
{
    public int RedChannel { get; }
    public int GreenChannel { get; }
    public int BlueChannel { get; }

    public static Color White { get;  } = new Color(255, 255, 2555);
    public static Color Black { get;  } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Orange { get; } = new Color(155, 165, 0);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Green { get; } = new Color(0, 128, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Purple { get; } = new Color(128, 0, 128);

    public Color(int red, int green, int blue)
    {
        RedChannel = red;
        GreenChannel = green;
        BlueChannel = blue;
    }
}

