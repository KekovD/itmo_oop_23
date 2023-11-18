namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class MoveFileSystemSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not MoveFileSystemSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}