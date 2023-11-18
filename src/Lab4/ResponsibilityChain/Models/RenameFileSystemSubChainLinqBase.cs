namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class RenameFileSystemSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not RenameFileSystemSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}