using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Entities;

public class FileMoveCommandLinq : CommandChainLinkBase
{
    private readonly FlagsFileMoveSubChainLinqBase? _flagsChain;

    private FileMoveCommandLinq(FlagsFileMoveSubChainLinqBase? flagsChain)
    {
        _flagsChain = flagsChain;
    }

    public static IFileMoveCommandBuilder Builder() => new FileMoveCommandBuilder();

    public override CommandBase? Handle(CommandRequest request)
    {
        const string firstArgument = "file";
        const string secondArgument = "move";
        const int targetCount = 4;
        const int firstIndex = 0;
        const int secondIndex = 1;
        const int pathIndex = 2;

        if (request.Body.Count == targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal) &&
            request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
        {
            _flagsChain?.Handle(request);

            return new FileMoveCommand(request with { PathIndex = pathIndex });
        }

        return Next?.Handle(request);
    }

    private class FileMoveCommandBuilder : IFileMoveCommandBuilder
    {
        private FlagsFileMoveSubChainLinqBase? _flagsChain;

        public IFileMoveCommandBuilder WithFlagsSubChain(FlagsFileMoveSubChainLinqBase flagsChain)
        {
            _flagsChain = flagsChain;
            return this;
        }

        public FileMoveCommandLinq Create() => new(_flagsChain);
    }
}