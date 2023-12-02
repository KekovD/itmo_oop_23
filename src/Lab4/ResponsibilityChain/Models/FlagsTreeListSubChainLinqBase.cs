namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class FlagsTreeListSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not FlagsTreeListSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}