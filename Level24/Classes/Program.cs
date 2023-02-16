using Classes;

Console.Title = "Classes";
// Point
Point origin = new();
Point point2 = new(2, 3);
Point point3 = new(-4, 0);

Console.WriteLine($"{origin.X} : {origin.Y}");
Console.WriteLine($"{point2.X} : {point2.Y}");
Console.WriteLine($"{point3.X} : {point3.Y}");

// Color

Color randomColor = new(14, 92, 45);

Color red = Color.Red;

Console.WriteLine($"R:{randomColor.R} G:{randomColor.G} B:{randomColor.B}");
Console.WriteLine($"R:{red.R} G:{red.G} B:{red.B}");

// Cards

foreach(CardColor color in Enum.GetValues(typeof(CardColor))) {
    foreach(CardRank rank in Enum.GetValues(typeof(CardRank)))
    {
        Card card = new(color, rank);
        Console.WriteLine($"The {card.Color} {card.Rank}");
    }
}

// Validator

for (int i = 0; i < 10; i++)
{
    Console.Write("give some password to validate: ");
    string? password = Console.ReadLine();
    bool isValid = PasswordValidator.IsValid(password ?? "false");
    Console.WriteLine($"{password} is {(isValid ? "valid" : "invalid")}");
}


// Door

Door door = new(123);

while(true)
{
    Console.Write($"Door is {door.State}. What do you want to do (lock, unlock, open, close, change-passcode): ");
    string input = Console.ReadLine();
    switch(input)
    {
        case "lock":
            door.Lock();
            break;
        case "unlock":
            Console.Write("Passcode: ");
            int passcode = Convert.ToInt32(Console.ReadLine());
            door.Unlock(passcode);
            break;
        case "open":
            door.Open(); break;
        case "close":
            door.Close(); break;
        case "change-passcode":
            Console.Write("Old passcode: ");
            int oldPasscode = Convert.ToInt32(Console.ReadLine());
            Console.Write("New passcode: ");
            int newPasscode = Convert.ToInt32(Console.ReadLine());
            door.ChangePasscode(oldPasscode, newPasscode);
            break;
        default:
            continue;
    }
}