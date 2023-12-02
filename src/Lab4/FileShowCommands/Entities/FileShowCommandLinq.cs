using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;

public class FileShowCommandLinq : CommandChainLinkBase
{
    private readonly FlagsFileShowSubChainLinkBase? _chain;

    private FileShowCommandLinq(FlagsFileShowSubChainLinkBase? chain)
    {
        _chain = chain;
    }

    public static IFileShowCommandBuilder Builder() => new FileShowCommandBuilder();

    public override CommandBase? Handle(CommandRequest request)
    {
        const string firstArgument = "file";
        const string secondArgument = "show";
        const int targetCount = 3;
        const int firstIndex = 0;
        const int secondIndex = 1;

        if (request.Body.Count == targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal) &&
            request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
            return _chain?.Handle(request);

        return Next?.Handle(request);
    }

    private class FileShowCommandBuilder : IFileShowCommandBuilder
    {
        private FlagsFileShowSubChainLinkBase? _chain;

        public IFileShowCommandBuilder WithSubChain(FlagsFileShowSubChainLinkBase chain)
        {
            _chain = chain;
            return this;
        }

        public FileShowCommandLinq Create() => new(_chain);
    }
}