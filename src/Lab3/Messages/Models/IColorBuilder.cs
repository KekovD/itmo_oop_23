using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface IColorBuilder
{
    ITitleBuilder WithColor(Color color);
}