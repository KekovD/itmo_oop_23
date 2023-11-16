using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Models;

public interface IDisconnectCommandBuilder
{
    IDisconnectCommandBuilder WithContext(IContext context);
    IDisconnectCommandBuilder WithSubChain(FlagsDisconnectSubChainLinqBase chain);
    DisconnectCommand Crate();
}