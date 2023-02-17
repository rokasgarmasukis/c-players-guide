Console.Title = "Labeling Inventory";

Pack pack = new(10, 10, 10);


while (true)
{
    Console.WriteLine(pack.ToString());
    string choice = GetInput("Would you like to know the stats or add item (stats, add): ");
    switch (choice)
    {
        case "add":
            string itemChoice = GetInput("arrow, bow, rope, water, food, sword: ");
            switch (itemChoice)
            {
                case "arrow":
                    pack.Add(new Arrow());
                    break;
                case "bow":
                    pack.Add(new Bow());
                    break;
                case "rope":
                    pack.Add(new Rope());
                    break;
                case "water":
                    pack.Add(new Water());
                    break;
                case "food":
                    pack.Add(new Food());
                    break;
                case "sword":
                    pack.Add(new Sword());
                    break;
                default:
                    break;
            }
            break;
        case "stats":
            pack.PrintStats();
            break;
        default:
            break;
    }
}


string GetInput(string text)
{
    Console.Write(text);
    return Console.ReadLine();
}

public class Pack
{
    private InventoryItem[] _items { get; }
    public double MaxWeight { get; }
    public double MaxVolume { get; }
    public int MaxCount { get; }

    public double CurrentWeight { get; private set; }

    public double CurrentVolume { get; private set; }
    public int CurrentCount { get; private set; }

    public Pack(int numOfItems, double maxweight, double maxvolume)
    {
        MaxCount = numOfItems;
        MaxWeight = maxweight;
        MaxVolume = maxvolume;
        _items = new InventoryItem[numOfItems];
    }

    public bool Add(InventoryItem item)
    {
        if (CurrentVolume + item.Volume > MaxVolume) return false;
        if (CurrentWeight + item.Weight > MaxWeight) return false;
        if (CurrentCount == MaxCount) return false;

        _items[CurrentCount] = item;
        CurrentCount++;
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;

        return true;
    }

    public void PrintStats()
    {
        Console.WriteLine($"Items: {CurrentCount}/{MaxCount}, Volume: {CurrentVolume}/{MaxVolume}, Weight: {CurrentWeight}/{MaxWeight}");
    }

    public override string ToString()
    {
        string contents = "Pack containing:";
        foreach(InventoryItem item in _items)
        {
            contents += $" {item}";
        }

        return contents;
    }
}



public class InventoryItem
{
    public double Weight { get; set; }
    public double Volume { get; set; }

    public InventoryItem(double weight, double volume) { Weight = weight; Volume = volume; }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05) { }

    public override string ToString()
    {
        return "Arrow";
    }
}
public class Bow : InventoryItem
{
    public Bow() : base(1, 4) { }

    public override string ToString()
    {
        return "Bow";
    }
}
public class Rope : InventoryItem
{
    public Rope() : base(1, 1.5) { }
    public override string ToString()
    {
        return "Rope";
    }
}
public class Water : InventoryItem
{
    public Water() : base(2, 3) { }
    public override string ToString()
    {
        return "Water";
    }
}
public class Food : InventoryItem
{
    public Food() : base(1, 0.5) { }

    public override string ToString()
    {
        return "Food";
    }
}
public class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }

    public override string ToString()
    {
        return "Sword";
    }

}

