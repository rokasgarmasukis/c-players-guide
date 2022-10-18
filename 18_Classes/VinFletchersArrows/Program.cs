Console.Title = "Vin Fletcher's Arrows";

Arrow arrow = GetArrow();
Console.WriteLine(arrow.GetCost());

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
        Console.WriteLine("What length (60-100): ");
        length = Convert.ToInt32(Console.ReadLine());   
    } 
    return length;
}

Arrowhead GetArrowhead()
{
    Console.WriteLine("What type of arrowhead (steel, wood, obsidian): ");
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
    Console.WriteLine("What type of fletching (plastic, goose-feathers, turkey-feathers): ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => Fletching.Plastic,
        "goose-feathers" => Fletching.GooseFeathers,
        "turkey-feathers" => Fletching.TurkeyFeathers,
    };
}

class Arrow
{
    public Arrowhead _arrowhead;
    public float _length;
    public Fletching _fletching;

    public Arrow(Arrowhead arrowhead, float length, Fletching fletching)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    public float GetCost()
    {
        float costArrowhead = _arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5,
        };
        float costLength = _length * 0.05f;
        float costFletching = _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3,
        };
        return costArrowhead + costLength + costFletching;
    }
}

enum Arrowhead { Steel, Wood, Obsidian };
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers };