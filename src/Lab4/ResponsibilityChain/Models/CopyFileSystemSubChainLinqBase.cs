namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class CopyFileSystemSubChainLinqBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not CopyFileSystemSubChainLinqBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}