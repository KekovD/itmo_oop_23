namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class FlagsTreeGoToSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not FlagsTreeGoToSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}