﻿Console.Title = "The Old Robot";

Robot robot = new();

for (int i = 0; i < robot.Commands.Length; i++)
{
    string input = Console.ReadLine();
    IRobotCommand command = input switch
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



public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }


}

public interface IRobotCommand { void Run(Robot robot); }

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) { robot.Y++; }
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) { robot.Y--; }
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) { robot.X++; }
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}