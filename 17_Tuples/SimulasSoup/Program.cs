Console.Title = "Simula's Soup";
(SoupType type, MainIngredient ingredient, Seasoning seasoning) soup = GetSoup();
Console.WriteLine($"{soup.seasoning} {soup.ingredient} {soup.type}");

(SoupType, MainIngredient, Seasoning) GetSoup()
{
    SoupType soupType = GetSoupType();
    MainIngredient mainIngredient = GetMainIngredient();
    Seasoning seasoning = GetSeasoning();
    return (soupType, mainIngredient, seasoning);
}

Seasoning GetSeasoning()
{
    Console.WriteLine("Which seasoning (spicy, salty, sweet): ");
    string input = Console.ReadLine();
    return input switch
    {
        "spicy" => Seasoning.Spicy,
        "salty" => Seasoning.Salty,
        "sweet" => Seasoning.Sweet,
    };
}

MainIngredient GetMainIngredient()
{
    Console.WriteLine("Which main ingredient (mushrooms, chicken, carrots, potatoes): ");
    string input = Console.ReadLine();
    return input switch
    {
        "mushrooms" => MainIngredient.Mushrooms,
        "chicken" => MainIngredient.Chicken,
        "carrots" => MainIngredient.Carrots,
        "potatoes" => MainIngredient.Potatoes,
    };
}

SoupType GetSoupType()
{
    Console.WriteLine("Which soup type (soup, stew, gumbo): ");
    string input = Console.ReadLine();
    return input switch
    {
        "soup" => SoupType.Soup,
        "stew" => SoupType.Stew,
        "gumbo" => SoupType.Gumbo,
    };
}

enum SoupType { Soup, Stew, Gumbo };
enum MainIngredient { Mushrooms, Chicken, Carrots, Potatoes };
enum Seasoning { Spicy, Salty, Sweet };