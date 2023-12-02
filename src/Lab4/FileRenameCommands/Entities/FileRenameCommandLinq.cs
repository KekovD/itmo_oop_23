using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Entities;

public class FileRenameCommandLinq : CommandChainLinkBase
{
    private readonly FlagsFileRenameSubChainLinqBase? _flagsChain;

    private FileRenameCommandLinq(FlagsFileRenameSubChainLinqBase? flagsChain)
    {
        _flagsChain = flagsChain;
    }

    public static IFileRenameCommandBuilder Builder() => new FileRenameCommandBuilder();

    public override CommandBase? Handle(CommandRequest request)
    {
        const string firstArgument = "file";
        const string secondArgument = "rename";
        const int targetCount = 4;
        const int firstIndex = 0;
        const int secondIndex = 1;
        const int pathIndex = 2;

        if (request.Body.Count >= targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal) &&
            request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
        {
            _flagsChain?.Handle(request);

            return new FileRenameCommand(request with { PathIndex = pathIndex });
        }

        return Next?.Handle(request);
    }

    private class FileRenameCommandBuilder : IFileRenameCommandBuilder
    {
        private FlagsFileRenameSubChainLinqBase? _flagsChain;

        public IFileRenameCommandBuilder WithFlagsSubChain(FlagsFileRenameSubChainLinqBase flagsChain)
        {
            _flagsChain = flagsChain;
            return this;
        }

        public FileRenameCommandLinq Create() => new(_flagsChain);
    }
}