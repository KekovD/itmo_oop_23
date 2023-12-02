using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Entities;

public class FileCopyCommandLinq : CommandChainLinkBase
{
    private readonly FlagsFileCopySubChainLinqBase? _flagsChain;

    private FileCopyCommandLinq(FlagsFileCopySubChainLinqBase? flagsChain)
    {
        _flagsChain = flagsChain;
    }

    public static IFileCopyCommandBuilder Builder() => new FileCopyCommandBuilder();

    public override CommandBase? Handle(CommandRequest request)
    {
        const string firstArgument = "file";
        const string secondArgument = "copy";
        const int targetCount = 4;
        const int firstIndex = 0;
        const int secondIndex = 1;
        const int pathIndex = 2;

        if (request.Body.Count == targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal) &&
            request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
        {
            _flagsChain?.Handle(request);

            return new FileCopyCommand(request with { PathIndex = pathIndex });
        }

        return Next?.Handle(request);
    }

    private class FileCopyCommandBuilder : IFileCopyCommandBuilder
    {
        private FlagsFileCopySubChainLinqBase? _flagsChain;

        public IFileCopyCommandBuilder WithFlagsSubChain(FlagsFileCopySubChainLinqBase flagsChain)
        {
            _flagsChain = flagsChain;
            return this;
        }

        public FileCopyCommandLinq Create() => new(_flagsChain);
    }
}