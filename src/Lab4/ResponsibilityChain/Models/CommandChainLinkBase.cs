namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

public abstract class CommandChainLinkBase : ChainLinkBase
{
    public override void AddNext(ChainLinkBase link)
    {
        if (link is not CommandChainLinkBase) return;
        Next?.AddNext(link);
        Next ??= link;
    }
}