using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public interface IChainLink
{
    void AddNext(IChainLink link);

    void Handle(Request request);
}