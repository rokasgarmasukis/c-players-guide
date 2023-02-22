Console.Title = "Charberry Trees";

CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();




public class CharberryTree
{
    public event Action? Ripened;

    private Random _random = new Random();
    public bool Ripe { get; set; }
    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.000000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

public class Notifier
{
    public void OnRipened() => Console.WriteLine("A charberry fruit has ripened!");

    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnRipened;
    }
}

public class Harvester
{
    private int _harvestCount;
    private CharberryTree _tree;
    public void OnRipened()
    {
        _tree.Ripe = false;
        _harvestCount++;
        Console.WriteLine($"Fruit has been harvested {_harvestCount} times.");

    }

    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        tree.Ripened += OnRipened;
    }
}