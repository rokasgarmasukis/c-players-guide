Console.Title = "Packing Inventory";

Pack pack = new Pack(10, 10, 10);


while (true)
{
    Console.WriteLine("What do you want to do? (look-inside, add-arrow, add-bow, add-rope, add-water, add-food, add-sword");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "look-inside":
            pack.PrintStats();
            break;
        case "add-arrow":
            pack.Add(new Arrow());
            break;
        case "add-bow":
            pack.Add(new Bow());
            break;
        case "add-rope":
            pack.Add(new Rope());
            break;
        case "add-water":
            pack.Add(new Water());
            break;
        case "add-food":
            pack.Add(new Food());
            break;
        case "add-sword":
            pack.Add(new Sword());
            break;
        default:
            continue;
    }
}

class Pack
{
    private int MaxItems { get; init; }
    private double MaxWeight { get; init; }
    private double MaxVolume { get; init; }

    public int Items { get; private set; }
    public double Weight { get; private set; }
    public double Volume { get; private set; }

    private InventoryItem[] InventoryItems { get; set; }

    public Pack(int maxItems, double maxWeight, double maxVolume)
    {
        MaxItems = maxItems;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        Items = 0;
        InventoryItems = new InventoryItem[maxItems];
    }

    public void PrintStats()
    {
        Console.WriteLine($"Items: {Items}/{MaxItems}, Weight: {Weight}/{MaxWeight}, Volume: {Volume}/{MaxVolume}");
        Console.Write("Current items in the pack: ");
        for (int i = 0; i < Items; i++)
        {
            Console.Write($"{InventoryItems[i].GetType()} ");
        }
        Console.WriteLine();
    }

    public bool Add(InventoryItem item)
    {
        if (Items < MaxItems && (MaxWeight - Weight) > item.Weight && (MaxVolume - Volume) > item.Volume)
        {
            InventoryItems[Items] = item;
            Weight = Weight + item.Weight;
            Volume = Volume + item.Volume;
            Items++;
            return true;
        }
        else return false;
    }
}

class InventoryItem
{
    public double Weight { get; set; }
    public double Volume { get; set; }

    public InventoryItem(double weight, double volume)
    {
        this.Weight = weight;
        this.Volume = volume;
    }
}

class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05) { }

    public override String ToString() => "Rope";
}

class Bow : InventoryItem
{
    public Bow() : base(1, 4) { }
    public override String ToString() => "Bow";
}

class Rope : InventoryItem
{
    public Rope() : base(1, 1.5) { }
}

class Water : InventoryItem { public Water() : base(2, 3) { } }

class Food : InventoryItem
{
    public Food() : base(1, 0.5) { }
}

class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }
}