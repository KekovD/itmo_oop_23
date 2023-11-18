namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class FlagsFileShowSubChainLinkBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not FlagsFileShowSubChainLinkBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}