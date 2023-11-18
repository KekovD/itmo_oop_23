namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class DepthFlagSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not DepthFlagSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}