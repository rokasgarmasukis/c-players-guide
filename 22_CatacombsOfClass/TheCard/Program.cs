Console.Title = "The Card";

Rank[] ranks = { Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, Rank.Ten, Rank.DollarSign, Rank.Percent, Rank.Caret, Rank.Ampersand };
Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Yellow };


foreach (Color color in colors)
{
    foreach (Rank rank in ranks)
    {
        Card card = new Card(color, rank);
        Console.WriteLine($"The {card.Color} {card.Rank}");
    }
}

public class Card
{
    public Color Color { get; }
    public Rank Rank { get; }

    public Card(Color color, Rank rank)
    {
        Color = color;
        Rank = rank;
    }

    public bool IsSymbol => Rank == Rank.DollarSign || Rank == Rank.Percent || Rank == Rank.Caret || Rank == Rank.Ampersand;
    public bool IsNumber => !IsSymbol;
}

public enum Color { Red, Green, Blue, Yellow };
public enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand };