Console.Title = "Simula's Test";

DoorStatus doorStatus = DoorStatus.Locked;

while (true)
{
    Console.Write($"The door is {doorStatus.ToString().ToLower()}. What do you want to do? ");
    doorStatus = GetNewDoorStatus(doorStatus);

}


DoorStatus GetNewDoorStatus(DoorStatus doorStatus)
{

    string input = Console.ReadLine();
    if (input == "unlock" && doorStatus == DoorStatus.Locked)
    {
        return DoorStatus.Unlocked;
    }
    else if (input == "lock" && doorStatus == DoorStatus.Unlocked)
    {
        return DoorStatus.Locked;
    }
    else if (input == "open" && doorStatus == DoorStatus.Unlocked)
    {
        return DoorStatus.Open;
    }
    else if (input == "close" && doorStatus == DoorStatus.Open)
    {
        return DoorStatus.Unlocked;
    }
    else
    {
        return doorStatus;
    }
}

enum DoorStatus { Locked, Unlocked, Open }