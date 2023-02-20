Console.Title = "War Preparations";

Sword basicSword = new(Material.Iron, Gemstone.None);
Sword swordOne = basicSword with { Material = Material.Steel, Gemstone = Gemstone.Emerald, Length = 60 };
Sword swordTwo = basicSword with { Material = Material.Binarium, Gemstone = Gemstone.Bitstone };
Console.WriteLine(basicSword);
Console.WriteLine(swordOne);
Console.WriteLine(swordTwo);

public record Sword(Material Material, Gemstone Gemstone, double Length = 50, double CrossguardWidth = 10);
public enum Material { Wood, Bronze, Iron, Steel, Binarium};
public enum Gemstone { Emerald, Amber, Sapphire, Diamond, Bitstone, None};