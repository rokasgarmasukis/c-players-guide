using BetterRandom;

Console.Title = "Better Random";

Random random = new Random();
double rand = random.NextDouble(10);
Console.WriteLine(rand);

string rand2 = random.NextString("left", "right");
Console.WriteLine(rand2);

//int result = 0;
//bool validNumber = false;
//while (!validNumber) {
//    Console.Write("Give me a valid number: ");
//    string s = Console.ReadLine();
//    validNumber = int.TryParse(s, out result);
//}
//Console.WriteLine($"You entered: {result}");

int result;
do
{
    Console.Write("Give me a valid number: ");
} while (!int.TryParse(Console.ReadLine(), out result));
Console.WriteLine($"You entered: {result}");

double result2;
do
{
    Console.Write("Dive me a valid double: ");
} while (!double.TryParse(Console.ReadLine(),out result2));
Console.WriteLine($"You entered {result2}");

bool truth;
do
{
    Console.Write("True or false: ");
} while(!bool.TryParse(Console.ReadLine(),out truth));
Console.WriteLine(truth);