using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class ChainLinkBase : IChainLink
{
    protected IChainLink? Next { get; private set; }

    public void AddNext(IChainLink link)
    {
        Next?.AddNext(link);
        Next ??= link;
    }

    public abstract void Handle(Command request);
}