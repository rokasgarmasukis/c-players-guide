Console.Title = "Colored Items";


ColoredItem<Sword> blueSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.DarkBlue);
ColoredItem<Bow> magentaBow = new ColoredItem<Bow>(new(), ConsoleColor.Magenta);
ColoredItem<Axe> yellowAxe = new ColoredItem<Axe>(new(), ConsoleColor.Yellow);

blueSword.Display();
magentaBow.Display();
yellowAxe.Display();

public class ColoredItem<T>
{
    public ConsoleColor Color { get; }
    public T Item { get; }

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item);
    }
}


public class Sword { }
public class Bow { }
public class Axe { }

internal record struct NewStruct(ConsoleColor color, object Item2)
{
    public static implicit operator (ConsoleColor color, object)(NewStruct value)
    {
        return (value.color, value.Item2);
    }

    public static implicit operator NewStruct((ConsoleColor color, object) value)
    {
        return new NewStruct(value.color, value.Item2);
    }
}