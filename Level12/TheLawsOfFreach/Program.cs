Console.Title = "The Laws of Freach";

int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

// calculating minimum
int currentSmallest = int.MaxValue; // Start higher than anything in the array. 
foreach (int value in array)
{
    if (value < currentSmallest)
        currentSmallest= value;
}
Console.WriteLine(currentSmallest);

// calculating average
int total = 0;
foreach (int value in array)
    total += value;
float average = (float)total / array.Length;
Console.WriteLine(average);