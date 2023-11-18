namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class FlagsFileDeleteSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not FlagsFileDeleteSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}