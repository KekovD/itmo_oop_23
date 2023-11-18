namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class ModeFlagSubChainLinkBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not ModeFlagSubChainLinkBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}