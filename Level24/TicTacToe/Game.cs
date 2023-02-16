namespace TicTacToe;

public class Game
{
    public string[] Tiles { get; set; } = new string[9];
    public int CurrentPlayerID { get; private set; }

    public Game()
    {
        Array.Fill(Tiles, " ");
    }

    public bool makeMove(int choice, Player player)
    {
        if (Tiles[choice - 1] != " ") return false;

        CurrentPlayerID = player.ID;

        Tiles[choice - 1] = player.ID == 0 ? "O" : "X";
        return true;
    }

    public void DisplayGame()
    {
        Console.WriteLine($" {Tiles[6]} | {Tiles[7]} | {Tiles[8]}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Tiles[3]} | {Tiles[4]} | {Tiles[5]}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Tiles[0]} | {Tiles[1]} | {Tiles[2]}");
    }

    public bool IsWinner()
    {
        if (Tiles[0] == Tiles[1] &&  Tiles[1] == Tiles[2] && !Tiles[1].Equals(" ")) return true;
        if (Tiles[3] == Tiles[4] && Tiles[4] == Tiles[5] && !Tiles[3].Equals(" ")) return true;
        if (Tiles[6] == Tiles[7] && Tiles[7] == Tiles[8] && !Tiles[6].Equals(" ")) return true;
        if (Tiles[6] == Tiles[3] && Tiles[3] == Tiles[0] && !Tiles[6].Equals(" ")) return true;
        if (Tiles[8] == Tiles[5] && Tiles[5] == Tiles[2] && !Tiles[8].Equals(" ")) return true;
        if (Tiles[7] == Tiles[4] && Tiles[4] == Tiles[1] && !Tiles[7].Equals(" ")) return true;
        if (Tiles[6] == Tiles[4] && Tiles[4] == Tiles[2] && !Tiles[6].Equals(" ")) return true;
        if (Tiles[0] == Tiles[4] && Tiles[4] == Tiles[8] && !Tiles[0].Equals(" ")) return true;

        return false;
    }

    public bool AllMarked()
    {
        bool allMarked = true;
        foreach (string tile in Tiles)
        {
            if (tile.Equals(" ")) allMarked = false;
        }
        return allMarked;
    }
}

