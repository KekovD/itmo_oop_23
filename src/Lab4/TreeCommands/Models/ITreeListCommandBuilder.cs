using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

public interface ITreeListCommandBuilder
{
    ITreeListCommandBuilder WithContext(IContext context);
    ITreeListCommandBuilder WithSubChain(FlagsTreeListSubChainLinqBase chain);
    TreeListCommand Crate();
}