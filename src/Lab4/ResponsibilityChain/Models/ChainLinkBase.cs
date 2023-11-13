using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class ChainLinkBase : IChainLink
{
    private IChainLink? _next;

    public void AddNext(IChainLink link)
    {
        _next?.AddNext(link);
        _next ??= link;
    }

    public abstract void Handle(Request request);
}