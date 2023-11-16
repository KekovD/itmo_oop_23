using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

public interface IDepthFlagBuilder
{
    IDepthFlagBuilder WithContext(IContext context);
    IDepthFlagBuilder WithSubChain(DepthFlagSubChainLinqBase chain);
    DepthFlag Crate();
}