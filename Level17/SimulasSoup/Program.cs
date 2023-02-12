Console.Title = "Simula's Soup";


(FoodType foodType, MainIngredient mainIngredient, Seasoning seasoning) soup;

soup.foodType = GetFoodType();
soup.mainIngredient = GetMainIngredient();
soup.seasoning = GetSeasoning();

Console.WriteLine($"{soup.seasoning} {soup.mainIngredient} {soup.foodType}");


FoodType GetFoodType()
{
    while (true)
    {
        Console.Write("What kind of meal (soup, stew, gumbo): ");
        string input = Console.ReadLine();
        if (input == "soup") return FoodType.Soup;
        if (input == "stew") return FoodType.Stew;
        if (input == "gumbo") return FoodType.Gumbo;
    }
}

MainIngredient GetMainIngredient()
{
    while (true)
    {
        Console.Write("What kind of main ingredient (mushrooms, chicken, carrots, potatoes): ");
        string input = Console.ReadLine();
        if (input == "mushrooms") return MainIngredient.Mushrooms;
        if (input == "chicken") return MainIngredient.Chicken;
        if (input == "carrots") return MainIngredient.Carrots;
        if (input == "potatoes") return MainIngredient.Potatoes;
    }
}

Seasoning GetSeasoning()
{
    while (true)
    {
        Console.Write("What kind of seasoning (sweet, spicy, salty): ");
        string input = Console.ReadLine();
        if (input == "sweet") return Seasoning.Sweet;
        if (input == "spicy") return Seasoning.Spicy;
        if (input == "salty") return Seasoning.Salty;
    }
}

enum FoodType { Soup, Stew, Gumbo};
enum MainIngredient { Mushrooms, Chicken, Carrots, Potatoes };
enum Seasoning { Spicy, Salty, Sweet };