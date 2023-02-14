Console.Title = "Arrow Factories";


while (true)
{
    Console.Write("Would you like a pre-defined or custom arrow: ");
    string input = Console.ReadLine();
    Arrow arrow;
    if (input == "pre-defined")
    {
        Console.Write("elite, beginner, or marksman: ");
        input = Console.ReadLine();
        arrow = input switch
        {
            "elite" => Arrow.CreateEliteArrow(),
            "beginner" => Arrow.CreateBeginnerArrow(),
            "marksman" => Arrow.CreateMarksmanArrow(),
        };
    }
    else
    {
        arrow = GetArrow();
    }
    Console.WriteLine($"The arrow will cost {arrow.GetCost()} gold.");
}

Arrowhead GetArrowhead()
{
    Console.Write("Which arrowhead (steel, wood, obsidian): ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian,
    };
}
Fletching GetFletching()
{
    Console.Write("Which fletching (plastic, turkeyfeathers, goosefeathers): ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => Fletching.Plastic,
        "turkeyfeathers" => Fletching.TurkeyFeathers,
        "goosefeathers" => Fletching.GooseFeathers,
    };
}
float GetShaftLength()
{
    while (true)
    {
        Console.Write("Which shaft length (60 - 100): ");
        float input = int.Parse(Console.ReadLine());
        if (input >= 60 && input <= 100) return input;
    }
}

Arrow GetArrow()
{
    Arrowhead arrowhead = GetArrowhead();
    Fletching fletching = GetFletching();
    float length = GetShaftLength();
    return new Arrow(arrowhead, fletching, length);
}

class Arrow
{
    private Arrowhead Arrowhead { get; }
    private float ShaftLength { get; }
    private Fletching Fletching { get; }

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        ShaftLength = length;
    }

    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65);

    public float GetCost()
    {
        float costArrowhead = Arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Obsidian => 5,
            Arrowhead.Wood => 3
        };

        float costFletching = Fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3,
        };

        float costShaft = ShaftLength * 0.05f;

        return costArrowhead + costFletching + costShaft;
    }
}

enum Arrowhead { Steel, Wood, Obsidian };
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers };