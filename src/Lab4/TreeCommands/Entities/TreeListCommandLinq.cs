using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

public class TreeListCommandLinq : CommandChainLinkBase
{
    private readonly FlagsTreeListSubChainLinqBase? _chain;

    private TreeListCommandLinq(FlagsTreeListSubChainLinqBase? chain)
    {
        _chain = chain;
    }

    public static ITreeListCommandBuilder Builder() => new TreeListCommandBuilder();

    public override CommandBase? Handle(CommandRequest request)
    {
        const int targetCount = 2;
        const int firstValueIndex = 0;
        const int secondValueIndex = 1;
        const string firstValue = "tree";
        const string secondValue = "list";

        if (request.Body.Count == targetCount &&
            request.Body[firstValueIndex].Equals(firstValue, StringComparison.Ordinal) &&
            request.Body[secondValueIndex].Equals(secondValue, StringComparison.Ordinal))
            return _chain?.Handle(request);

        return Next?.Handle(request);
    }

    private class TreeListCommandBuilder : ITreeListCommandBuilder
    {
        private FlagsTreeListSubChainLinqBase? _chain;

        public ITreeListCommandBuilder WithSubChain(FlagsTreeListSubChainLinqBase chain)
        {
            _chain = chain;
            return this;
        }

        public TreeListCommandLinq Create() => new(_chain);
    }
}