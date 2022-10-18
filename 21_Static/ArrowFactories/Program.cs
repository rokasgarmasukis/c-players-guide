Console.Title = "The Properties of Arrows";

Console.WriteLine("What kind of arrow would you like: ");
Console.WriteLine("1 - Elite Arrow");
Console.WriteLine("2 - Beginner Arrow");
Console.WriteLine("3 - Marksman Arrow");
Console.WriteLine("4 - Custom Arrow");

string input = Console.ReadLine();

Arrow arrow = input switch
{
    "1" => Arrow.CreateEliteArrow(),
    "2" => Arrow.CreateBeginnerArrow(),
    "3" => Arrow.CreateMarksmanArrow(),
    "4" => GetArrow(),
};

Console.WriteLine($"The arrow cost {arrow.GetCost()}");

Arrow GetArrow()
{
    float length = GetLength();
    Arrowhead arrowhead = GetArrowhead();
    Fletching fletching = GetFletching();
    return new Arrow(arrowhead, length, fletching);
}

float GetLength()
{
    float length = 0;
    while (length < 60 || length > 100)
    {
        Console.Write("What length (60-100): ");
        length = Convert.ToInt32(Console.ReadLine());
    }
    return length;
}

Arrowhead GetArrowhead()
{
    Console.Write("What type of arrowhead (steel, wood, obsidian): ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian
    };
}

Fletching GetFletching()
{
    Console.Write("What type of fletching (plastic, goose-feathers, turkey-feathers): ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => Fletching.Plastic,
        "goose-feathers" => Fletching.GooseFeathers,
        "turkey-feathers" => Fletching.TurkeyFeathers,
    };
}

class Arrow
{
    Arrowhead Arrowhead { get; }
    float Length { get; }
    Fletching Fletching { get; }

    public Arrow(Arrowhead arrowhead, float length, Fletching fletching)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = length;
    }

    public float GetCost()
    {
        float costArrowhead = Arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5,
        };
        float costLength = Length * 0.05f;
        float costFletching = Fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3,
        };
        return costArrowhead + costLength + costFletching;
    }

    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, 95, Fletching.Plastic);
    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, 75, Fletching.GooseFeathers);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, 65, Fletching.GooseFeathers);

}

enum Arrowhead { Steel, Wood, Obsidian };
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers };