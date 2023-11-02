using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Services;

public class ColorModifier : IRenderableModifier
{
    private readonly Color _color;

    public ColorModifier(Color color)
    {
        _color = color;
    }

    public string Modify(string value)
    {
        return Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(value);
    }
}