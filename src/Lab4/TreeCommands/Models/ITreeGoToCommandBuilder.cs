using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

public interface ITreeGoToCommandBuilder
{
    ITreeGoToCommandBuilder WithContext(IContext context);
    ITreeGoToCommandBuilder WithChain(FlagsTreeGoToSubChainLinqBase chain);
    TreeGoToCommand Crate();
}