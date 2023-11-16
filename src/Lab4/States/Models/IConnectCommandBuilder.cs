using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Models;

public interface IConnectCommandBuilder
{
    IConnectCommandBuilder WithSubChain(FlagsConnectSubChainLinqBase chain);
    IConnectCommandBuilder WithContext(IContext context);
    ConnectCommand Crate();
}