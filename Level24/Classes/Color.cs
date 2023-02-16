using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;
internal class Color
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    public Color(int red, int green, int blue)
    {
        R = red; G = green; B = blue;
    }

    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    
}
