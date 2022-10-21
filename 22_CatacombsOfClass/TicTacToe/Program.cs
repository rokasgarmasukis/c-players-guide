using System.Numerics;

Console.Title = "Tic-Tac-Toe";

Board board = new Board();
Player player1 = Player.Player1;
Player player2 = Player.Player2;
Player currentPlayer = player1;

while (true)
{
    Console.WriteLine("-------------------------------------");
    int choice = board.MakeRound(currentPlayer);
    board.Update(choice, currentPlayer);
    if (board.CheckForWin())
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("somebody won!");
        board.Display();
        Console.WriteLine("-------------------------------------");
        break;
    }
    currentPlayer = currentPlayer == player1 ? player2 : player1;
}

public class Board
{
    private Cell[] Cells { get; set; }

    private readonly int[][] _validWincombinations = { new int[3] { 0, 1, 2 }, new int[3] { 3, 4, 5 }, new int[3] { 6, 7, 8 }, new int[3] { 0, 3, 6 }, new int[3] { 1, 4, 7 }, new int[3] { 2, 5, 8 }, new int[3] { 0, 4, 8 }, new int[3] { 2, 4, 6 } };

    public Board()
    {
        Cells = new Cell[9];
        for (int i = 0; i < 9; i++)
        {
            Cells[i] = new Cell();
        }
    }

    public int MakeRound(Player player)
    {
        Console.WriteLine($"It is {(player == Player.Player1 ? "One" : "Two")} turn.");
        this.Display();
        int choice;
        Console.Write("Where do you want to place? ");
        while (true)
        {
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice < 1 || choice > 9)
            {
                Console.Write("Wrong number. Has to be between 1 and 9. Try again: ");
                continue;
            }
            if (this.Cells[choice - 1].Type != CellType.Empty)
            {
                Console.Write("Wrong number. It is not empty. Try again: ");
                continue;
            }
            break;
        }
        return choice;
    }

    public void Display()
    {
        Console.WriteLine($" {Cells[6].ShowCell()} | {Cells[7].ShowCell()} | {Cells[8].ShowCell()} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Cells[3].ShowCell()} | {Cells[4].ShowCell()} | {Cells[5].ShowCell()} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Cells[0].ShowCell()} | {Cells[1].ShowCell()} | {Cells[2].ShowCell()} ");
    }

    public void Update(int number, Player player)
    {
        if (player == Player.Player1) Cells[number - 1].Type = CellType.Player1;
        else if (player == Player.Player2) Cells[number - 1].Type = CellType.Player2;
    }

    public bool CheckForWin()
    {
        foreach (int[] combination in _validWincombinations)
        {
            if (this.Cells[combination[0]].Type == this.Cells[combination[1]].Type
                && this.Cells[combination[1]].Type == this.Cells[combination[2]].Type && this.Cells[combination[0]].Type != CellType.Empty)
            {
                return true;
            }
        }
        return false;
    }
} 

public class Cell
{
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
public enum Player { Player1, Player2 };