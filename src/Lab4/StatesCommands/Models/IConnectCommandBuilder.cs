using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public interface IConnectCommandBuilder
{
    IConnectCommandBuilder WithSubChain(FlagsConnectSubChainLinqBase chain);
    IConnectCommandBuilder WithContext(IContext context);
    ConnectCommand Create();
}