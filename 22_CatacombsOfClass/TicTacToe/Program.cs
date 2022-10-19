Console.Title = "Tic-Tac-Toe";

// generate new board
// loop:
//     receive input from player 1
//     receive input from player 2
//     eval
Player player1 = new Player();
Player player2 = new Player();


Board board = new Board();

board.DisplayBoard(player1, player2);



public class Player
{
    public bool IsTurn { get; set; }

    public Player()
    {
    }
}

public class Board
{
    public Cell[] Cells { get; set; }

    public Board()
    {
        Cells = new Cell[9];
        for (int i = 0; i < 9; i++)
        {
            Cells[i] = new Cell();
        }
    }

    public void DisplayBoard(Player playerOne, Player PlayerTwo)
    {
        Console.WriteLine($"It is {(playerOne.IsTurn ? "One" : "Two" )} turn.");
        Console.WriteLine($" {Cells[0].ShowCell()} | {Cells[1].ShowCell()} | {Cells[2].ShowCell()} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Cells[3].ShowCell()} | {Cells[4].ShowCell()} | {Cells[5].ShowCell()} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Cells[6].ShowCell()} | {Cells[7].ShowCell()} | {Cells[8].ShowCell()} ");
    }
}

public class Cell
{
    public Player Owner { get; set; }
    public CellType Type { get; set; }
    public Cell()
    {
        Type = CellType.Empty;
    }

    public string ShowCell()
    {
        if (Type == CellType.Player1) return "X";
        else if (Type == CellType.Player2) return "O";
        else return " ";
    }
}

public enum CellType { Empty, Player1, Player2 };