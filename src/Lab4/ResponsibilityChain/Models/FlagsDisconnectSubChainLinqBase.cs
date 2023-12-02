namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class FlagsDisconnectSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not FlagsDisconnectSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}