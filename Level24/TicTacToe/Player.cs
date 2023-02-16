namespace TicTacToe;

public class Player
{
    public string Name { get; }
    public int ID { get; }

    public Player(string name, int id)
    {
        Name = name;
        ID = id;
    }

    public int GetMove()
    {
        int input = 0;
        while (input < 1 || input > 9) {
            Console.Write($"{Name}, it is your turn: ");
            input = Convert.ToInt32(Console.ReadLine());
        }
        return input;
    }
}
