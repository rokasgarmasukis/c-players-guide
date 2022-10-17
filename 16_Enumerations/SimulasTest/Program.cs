Console.Title = "Simula's Test";

LockStatus lockStatus = LockStatus.Locked;

while (true)
{
    PrintLockStatus(lockStatus);
    string action = Console.ReadLine();
    lockStatus = DoAction(action, lockStatus);
}

LockStatus DoAction(string action, LockStatus lockStatus)
{
    if (lockStatus == LockStatus.Locked && action == "unlock") return LockStatus.Closed;
    else if (lockStatus == LockStatus.Closed && action == "lock") return LockStatus.Locked;
    else if (lockStatus == LockStatus.Closed && action == "open") return LockStatus.Open;
    else if (lockStatus == LockStatus.Open && action == "close") return LockStatus.Closed;
    else return lockStatus;
}

void PrintLockStatus(LockStatus lockStatus)
{
    Console.Write($"The chest is {lockStatus.ToString().ToLower()}. What do you want to do? ");
}

enum LockStatus { Locked, Closed, Open }