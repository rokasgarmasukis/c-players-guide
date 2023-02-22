Console.Title = "The Sieve";

Console.Write("Which filter would you like to have (even, positive, multipleof10): ");
string input = Console.ReadLine();
Sieve filter = input switch
{
    "even" => new Sieve(IsEven),
    "positive" => new Sieve(IsPositive),
    "multipleof10" => new Sieve(IsMultipleOf10)
};

while (true)
{
    int num = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"{num}: {filter.IsGood(num)}");
}


bool IsEven(int number) => number % 2 == 0;
bool IsPositive(int number) => number > 0;
bool IsMultipleOf10(int number) => number % 10 == 0;


public class Sieve
{
    private readonly Func<int, bool> _operation;

    public Sieve(Func<int, bool> operation) { _operation = operation; }

    public bool IsGood(int number) => _operation(number);
}