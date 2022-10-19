Console.Title = "The Locked Door";

Console.Write("Hi, please provide a new passcode for the door: ");
int passcode = Convert.ToInt32(Console.ReadLine());
Door door = new Door(passcode);

while (true)
{
    Console.Write($"The door is {door.Status}. What would you want to do (open, close, lock, unlock, change-passcode): ");
    string input = Console.ReadLine();
    switch (input)
    {
        case "open":
            door.OpenDoor();
            break;
        case "close":
            door.CloseDoor();
            break;
        case "lock":
            door.LockDoor();
            break;
        case "unlock":
            int pass = GetInt("What is your passcode?: ");
            door.UnlockDoor(passcode);
            break;
        case "change-passcode":
            int oldPasscode = GetInt("Old passcode: ");
            int newPasscode = GetInt("New passcode: ");
            door.ChangePasscode(oldPasscode, newPasscode);
            break;
        default:
            break;
    }
}

int GetInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

public class Door
{
    private int _passcode;
    public DoorStatus Status { get; private set; } 

    public Door(int passcode)
    {
        _passcode = passcode;
        Status = DoorStatus.Closed;
    }

    public void CloseDoor()
    {
        if (Status == DoorStatus.Open) Status = DoorStatus.Closed;
    }
    public void OpenDoor()
    {
        if (Status == DoorStatus.Closed) Status = DoorStatus.Open;
    }
    public void LockDoor()
    {
        if (Status == DoorStatus.Closed) Status = DoorStatus.Locked;
    }
    public void UnlockDoor(int passcode)
    {
        if (_passcode == passcode && Status == DoorStatus.Locked) Status = DoorStatus.Closed;
    }

    public void ChangePasscode(int oldPasscode, int newPasscode)
    {
        if (_passcode == oldPasscode)
        {
            _passcode = newPasscode;
            Console.WriteLine("The passcode has been changed.");
        } 

    }
}


public enum DoorStatus { Locked, Closed, Open };