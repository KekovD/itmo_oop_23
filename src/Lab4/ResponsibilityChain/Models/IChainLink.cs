using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public interface IChainLink
{
    void AddNext(IChainLink link);

    void Handle(Command request);
}