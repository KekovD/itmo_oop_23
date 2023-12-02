namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class FlagsFileCopySubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not FlagsFileCopySubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}