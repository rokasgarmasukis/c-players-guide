Console.Title = "The Old Robot";

Robot robot = new();

for (int i = 0; i < robot.Commands.Length; i++)
{
    string input = Console.ReadLine();
    RobotCommand command = input switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "west" => new WestCommand(),
        "east" => new WestCommand(),
    };
    robot.Commands[i] = command;
}

robot.Run();

//string[] commands = new string[3];
//commands[0] = Console.ReadLine();
//commands[1] = Console.ReadLine();
//commands[2] = Console.ReadLine();

//for (int i = 0; i < 3; i++)
//{
//    switch (commands[i])
//    {
//        case "off":
//            robot.Commands[i] = new OffCommand();
//            break;
//        case "on":
//            robot.Commands[i] = new OnCommand();
//            break;
//        case "west":
//            robot.Commands[i] = new WestCommand();
//            break;
//        case "east":
//            robot.Commands[i] = new EastCommand();
//            break;
//        case "north":
//            robot.Commands[i] = new NorthCommand();
//            break;
//        case "south":
//            robot.Commands[i] = new SouthCommand();
//            break;
//        default:
//            break;
//    }
//}



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

public abstract class RobotCommand { public abstract void Run(Robot robot); }

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = true;
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = false;
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) { robot.Y++; }
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) { robot.Y--; }
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) { robot.X++; }
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}