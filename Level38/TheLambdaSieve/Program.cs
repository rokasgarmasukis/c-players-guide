Console.Title = "The Lambda Sieve";

Console.Write("Which filter would you like to have (even, positive, multipleof10): ");
string input = Console.ReadLine();
Sieve filter = input switch
{
"even" => new Sieve(x => x % 2 == 0),
"positive" => new Sieve(x => x > 0),
"multipleof10" => new Sieve(x => x % 10 == 0)
};

while (true)
{
int num = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"{num}: {filter.IsGood(num)}");
}
public class Sieve
{
    private readonly Func<int, bool> _operation;

    public Sieve(Func<int, bool> operation) { _operation = operation; }

    public bool IsGood(int number) => _operation(number);
}