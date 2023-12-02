using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public interface IDisconnectCommandBuilder
{
    IDisconnectCommandBuilder WithSubChain(FlagsDisconnectSubChainLinqBase chain);
    DisconnectCommandLinq Create();
}