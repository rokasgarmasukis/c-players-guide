using TicTacToe;

Console.Title = "Tic-Tac-Toe";

Game game = new Game();

Console.Write("Player 1, please enter your name: ");
string? input = Console.ReadLine();
Player player1 = new Player(input ?? "Player 1", 0);

Console.Write("Player 2, please enter your name: ");
input = Console.ReadLine();
Player player2 = new Player(input ?? "Player 2", 1);


while(true)
{
    game.DisplayGame();
    while (true)
    {
        int move = player1.GetMove();
        if (game.makeMove(move, player1)) break;
    }
    
    if (game.AllMarked() || game.IsWinner()) break;

    game.DisplayGame();
    while (true)
    {
        int move = player2.GetMove();
        if (game.makeMove(move, player2)) break;
    }
    if (game.AllMarked() || game.IsWinner()) break;
}

game.DisplayGame();

if (game.IsWinner())
{
    string name = game.CurrentPlayerID == player1.ID ? player1.Name : player2.Name;
    Console.WriteLine($"Congratulations, {name}, you won!");
}
else
{
    Console.WriteLine("Draw!");
}
