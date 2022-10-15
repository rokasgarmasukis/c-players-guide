Console.Title = "The Replicator of D'TO";

int[] firstArray = new int[5];

for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Please enter a value #" + i);
    firstArray[i] = Convert.ToInt32(Console.ReadLine());
}

int[] secondArray = new int[5];

for (int i = 0; i < 5; i++)
    secondArray[i] = firstArray[i];

for (int i = 0; i < 5; i++)
    Console.WriteLine($"Original: {firstArray[i]}, Copied: {secondArray[i]}");