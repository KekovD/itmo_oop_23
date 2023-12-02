namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class FlagsConnectSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not FlagsConnectSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}