using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

public interface IDepthFlagBuilder
{
    IDepthFlagBuilder WithContext(IContext context);
    DepthFlag Create();
}