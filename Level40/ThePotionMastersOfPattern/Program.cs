Console.Title = "The Potion Masters of Pattern";

Potion potion = Potion.Water;

while (true)
{
    Console.WriteLine($"Current potion: {potion}");
    Console.Write("Do you want to add more ingredients? ");
    if (Console.ReadLine() == "no") break;
    ListIngredients();
    int choice = Convert.ToInt32(Console.ReadLine());
    Ingredient ingredient = choice switch
    {
        1 => Ingredient.Stardust,
        2 => Ingredient.SnakeVenom,
        3 => Ingredient.DragonBreath,
        4 => Ingredient.ShadowGlass,
        5 => Ingredient.EyeshineGem
    };

    potion = MakePotion(potion, ingredient);

    if (potion == Potion.Ruined)
    {
        Console.WriteLine("You've ruined your potion and have to start over.");
        potion = Potion.Water;
    }
}

void ListIngredients()
{
    Console.WriteLine("What would you like to add?");
    Console.Write("1 - Stardust, 2 - Snake Venom, 3 - Dragon Breath, 4 - Shadow Glass, 5 - Eyeshine Gem: ");
}

Potion MakePotion(Potion potion, Ingredient ingredient)
{
    return (potion, ingredient) switch
    {
        (Potion.Water, Ingredient.Stardust) => Potion.Elixir,
        (Potion.Elixir, Ingredient.SnakeVenom) => Potion.Poison,
        (Potion.Elixir, Ingredient.DragonBreath) => Potion.Flying,
        (Potion.Elixir, Ingredient.ShadowGlass) => Potion.Invisiblity,
        (Potion.Elixir, Ingredient.EyeshineGem) => Potion.NightSight,
        (Potion.NightSight, Ingredient.ShadowGlass) => Potion.CloudyBrew,
        (Potion.Invisiblity, Ingredient.EyeshineGem) => Potion.CloudyBrew,
        (Potion.CloudyBrew, Ingredient.Stardust) => Potion.Wraith,
        (_, _) n => Potion.Ruined
    };
}

enum Potion { Water, Elixir, Poison, Flying, Invisiblity, NightSight, CloudyBrew, Wraith, Ruined }
enum Ingredient { Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem }