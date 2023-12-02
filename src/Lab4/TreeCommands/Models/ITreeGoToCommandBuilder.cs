using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

public interface ITreeGoToCommandBuilder
{
    ITreeGoToCommandBuilder WithSubChain(FlagsTreeGoToSubChainLinqBase chain);
    TreeGoToCommandLinq Create();
}