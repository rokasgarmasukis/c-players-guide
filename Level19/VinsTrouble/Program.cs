Console.Title = "Vin's Trouble";
Arrow arrow = GetArrow();
Console.WriteLine($"The arrow will cost {arrow.GetCost()} gold.");

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
    private Arrowhead arrowhead;
    private float shaftLength;
    private Fletching fletching;

    public Arrowhead GetArrowhead() => arrowhead;
    public Fletching GetFletching() => fletching;
    public float GetShaftLength() => shaftLength;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        this.arrowhead= arrowhead;
        this.fletching = fletching;
        this.shaftLength = length;
    }

    public float GetCost()
    {
        float costArrowhead = arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Obsidian => 5,
            Arrowhead.Wood => 3
        };

        float costFletching = fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3,
        };

        float costShaft = shaftLength * 0.05f;

        return costArrowhead + costFletching + costShaft;
    }
}

enum Arrowhead { Steel, Wood, Obsidian };
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers };