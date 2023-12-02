namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class DeleteFileSystemSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not DeleteFileSystemSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}