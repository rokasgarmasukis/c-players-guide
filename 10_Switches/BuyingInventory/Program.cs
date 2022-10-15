using System.Security;

Console.Title = "Buying Inventory";

Console.WriteLine("The following items are available:");

Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");

Console.Write("What number do you want to see the price of? ");
int choice = Convert.ToInt32(Console.ReadLine());

Console.Write("What is your name? ");
string name = Console.ReadLine();

int price = choice switch
{
    1 => 10,
    2 => 15,
    3 => 25,
    4 => 1,
    5 => 20,
    6 => 200,
    7 => 1,
    _ => 0
};

if (name == "Rokas") price /= 2;

string item = choice switch
{
    1 => "Rope",
    2 => "Torches",
    3 => "Climbing equipment",
    4 => "Clean water",
    5 => "Machete",
    6 => "Canoe",
    7 => "Food supplies",
    _ => "You entered a wrong number, therefore it"
};

Console.WriteLine($"{item} cost {price} gold.");
