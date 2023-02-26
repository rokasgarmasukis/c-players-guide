Console.Title = "Asynchronous Random Words";

DateTime before = DateTime.Now;

int result = await RandomlyRecreateAsync("abcd");
Console.WriteLine(result);

TimeSpan diff = DateTime.Now - before;
Console.WriteLine(diff.Seconds);

int RandomlyRecreate(string word)
{
    char[] wordChars = word.ToCharArray();
    char[] newChars = new char[wordChars.Length];
    Random random = new Random();
    int times = 0;
    while (true)
    {
        for (int i = 0; i < wordChars.Length; i++)
        {
            newChars[i] = (char)('a' + random.Next(26));
            times++;
        }
        if ((new string(wordChars)).Equals(new string(newChars))) break;
    }
    return times;
}

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() =>
    {
        return RandomlyRecreate(word);
    });
}