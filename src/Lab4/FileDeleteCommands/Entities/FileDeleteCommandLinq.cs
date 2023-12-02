using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Entities;

public class FileDeleteCommandLinq : CommandChainLinkBase
{
    private readonly FlagsFileDeleteSubChainLinqBase? _flagsChain;

    private FileDeleteCommandLinq(FlagsFileDeleteSubChainLinqBase? flagsChain)
    {
        _flagsChain = flagsChain;
    }

    public static IFileDeleteCommandBuilder Builder() => new FileDeleteCommandBuilder();

    public override CommandBase? Handle(CommandRequest request)
    {
        const string firstArgument = "file";
        const string secondArgument = "delete";
        const int targetCount = 3;
        const int firstIndex = 0;
        const int secondIndex = 1;
        const int pathIndex = 2;

        if (request.Body.Count == targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal) &&
            request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
        {
            _flagsChain?.Handle(request);

            return new FileDeleteCommand(request with { PathIndex = pathIndex });
        }

        return Next?.Handle(request);
    }

    private class FileDeleteCommandBuilder : IFileDeleteCommandBuilder
    {
        private FlagsFileDeleteSubChainLinqBase? _flagsChain;

        public IFileDeleteCommandBuilder WithFlagsSubChain(FlagsFileDeleteSubChainLinqBase flagsChain)
        {
            _flagsChain = flagsChain;
            return this;
        }

        public FileDeleteCommandLinq Create() => new(_flagsChain);
    }
}