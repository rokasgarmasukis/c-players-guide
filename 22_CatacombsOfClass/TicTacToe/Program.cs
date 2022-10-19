Console.Title = "Tic-Tac-Toe";

// generate new board
// loop:
//     receive input from player 1
//     receive input from player 2
//     eval
Player player1 = new Player();
Player player2 = new Player();


Board board = new Board();

board.Display(player1, player2);

Console.Write("Where do you want to place? ");
int choice = Convert.ToInt32(Console.ReadLine());
board.Update(choice, 1);
board.Display(player1, player2);



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

    public void Display(Player playerOne, Player PlayerTwo)
    {
        Console.WriteLine($"It is {(playerOne.IsTurn ? "One" : "Two" )} turn.");
        Console.WriteLine($" {Cells[0].ShowCell()} | {Cells[1].ShowCell()} | {Cells[2].ShowCell()} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Cells[3].ShowCell()} | {Cells[4].ShowCell()} | {Cells[5].ShowCell()} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Cells[6].ShowCell()} | {Cells[7].ShowCell()} | {Cells[8].ShowCell()} ");
    }

    public void Update(int number, int player)
    {
        if (player == 1) Cells[number - 1].Type = CellType.Player1;
        else if (player == 2) Cells[number - 1].Type = CellType.Player2;
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