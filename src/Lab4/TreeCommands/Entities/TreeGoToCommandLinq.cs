using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

public class TreeGoToCommandLinq : CommandChainLinkBase
{
    private readonly FlagsTreeGoToSubChainLinqBase? _chain;

    private TreeGoToCommandLinq(FlagsTreeGoToSubChainLinqBase? chain)
    {
        _chain = chain;
    }

    public static ITreeGoToCommandBuilder Builder() => new TreeGoToCommandBuilder();

    public override CommandBase? Handle(CommandRequest request)
    {
        const int targetCount = 3;
        const int firstValueIndex = 0;
        const int secondValueIndex = 1;
        const string firstValue = "tree";
        const string secondValue = "goto";
        const int pathIndex = 2;

        if (request.Body.Count == targetCount &&
            request.Body[firstValueIndex].Equals(firstValue, StringComparison.Ordinal) &&
            request.Body[secondValueIndex].Equals(secondValue, StringComparison.Ordinal))
        {
            _chain?.Handle(request);

            return new TreeGoToCommand(request with { PathIndex = pathIndex });
        }

        return Next?.Handle(request);
    }

    private class TreeGoToCommandBuilder : ITreeGoToCommandBuilder
    {
        private FlagsTreeGoToSubChainLinqBase? _chain;

        public ITreeGoToCommandBuilder WithSubChain(FlagsTreeGoToSubChainLinqBase chain)
        {
            _chain = chain;
            return this;
        }

        public TreeGoToCommandLinq Create() => new(_chain);
    }
}