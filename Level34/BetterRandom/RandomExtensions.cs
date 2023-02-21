namespace BetterRandom;

public static class RandomExtensions
{
    public static double NextDouble(this Random random, int max) => random.NextDouble() * max;

    public static string NextString(this Random random, params string[] options) => options[random.Next(options.Length)];

    public static bool CoinFlip(this Random random, double frequencyOfHeads = 0.5) => random.NextDouble() < frequencyOfHeads;
}
