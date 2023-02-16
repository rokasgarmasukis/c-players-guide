namespace Classes;
public class Card
{
    public CardColor Color { get; }
    public CardRank Rank { get; }
    public bool IsSymbol => Rank == CardRank.DollarSign
                || Rank == CardRank.Percent
                || Rank == CardRank.Caret
                || Rank == CardRank.Ampersand;

    public bool IsNumber => !IsSymbol;

    public Card(CardColor color, CardRank rank)
    {
        Color = color; Rank = rank;
    }
}

public enum CardColor { Red, Green, Blue, Yellow };
public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand };