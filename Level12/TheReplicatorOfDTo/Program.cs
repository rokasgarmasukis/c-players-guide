Console.Title = "The Replicator of D’To";

int[] firstArray = new int[5];

firstArray[0] = int.Parse(Console.ReadLine());
firstArray[1] = int.Parse(Console.ReadLine());
firstArray[2] = int.Parse(Console.ReadLine());
firstArray[3] = int.Parse(Console.ReadLine());
firstArray[4] = int.Parse(Console.ReadLine());

int[] secondArray = new int[5];

for(int i = 0; i < 5; i++)
{
    secondArray[i] = firstArray[i];
}

for(int i = 0;i < 5; i++)
{
    Console.WriteLine($"first Array: {firstArray[i]}; copy: {secondArray[i]}");
}