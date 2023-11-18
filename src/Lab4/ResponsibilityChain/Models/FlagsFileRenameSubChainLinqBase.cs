namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class FlagsFileRenameSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not FlagsFileRenameSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}