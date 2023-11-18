namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class FlagsFileMoveSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not FlagsFileMoveSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}