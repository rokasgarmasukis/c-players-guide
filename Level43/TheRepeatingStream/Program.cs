Console.Title = "The Repeating Stream";

Thread thread = new Thread(NumGen);
RecentNumbers recentNums = new();

thread.Start(recentNums);

while(true)
{
    Console.ReadKey();
    if (recentNums.RecentNumberOne == recentNums.RecentNumberTwo)
        Console.WriteLine($"success {recentNums.RecentNumberOne} {recentNums.RecentNumberTwo}");
    else 
        Console.WriteLine("fail, not equal");
}

void NumGen(object? obj)
{
    if (obj == null) return;
    Random random = new();
    RecentNumbers recentNums = (RecentNumbers)obj;
    int num = random.Next(10);
    recentNums.RecentNumberOne = num;
    while (true)
    {
        Thread.Sleep(1000);
        num = random.Next(10);
        Console.WriteLine(num);
        recentNums.RecentNumberTwo = recentNums.RecentNumberOne;
        recentNums.RecentNumberOne = num;
    }
}



class RecentNumbers
{
    public int RecentNumberOne { get; set; }
    public int RecentNumberTwo { get; set; }
}