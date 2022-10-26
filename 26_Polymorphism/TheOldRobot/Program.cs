Console.Title = "The Old Robot";

int commands = 0;
Robot robot = new Robot();

while (commands < 3)
{
    string input = Console.ReadLine();
    switch (input)
    {
        case "on":
            robot.Commands[commands] = new OnCommand();
            commands++;
            break;
        case "off":
            robot.Commands[commands] = new OffCommand();
            commands++;
            break;
        case "north":
            robot.Commands[commands] = new NorthCommand();
            commands++;
            break;
        case "south":
            robot.Commands[commands] = new SouthCommand();
            commands++;
            break;
        case "west":
            robot.Commands[commands] = new WestCommand();
            commands++;
            break;
        case "east":
            robot.Commands[commands] = new EastCommand();
            commands++;
            break;
        default:
            continue;
    }
}


robot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y += 1;
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y -= 1;
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X -= 1;
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X += 1;
    }
}