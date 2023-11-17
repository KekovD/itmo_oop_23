using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;

public class FileShowCommand : CommandChainLinkBase
{
    private readonly IContext _context;
    private readonly FlagsFileShowSubChainLinkBase? _chain;

    private FileShowCommand(IContext context, FlagsFileShowSubChainLinkBase? chain)
    {
        _context = context;
        _chain = chain;
    }

    public static IFileShowCommandBuilder Builder() => new FileShowCommandBuilder();

    public override void Handle(Command request)
    {
        const string firstArgument = "file";
        const string secondArgument = "show";
        const int targetCount = 2;
        const int firstIndex = 0;
        const int secondIndex = 1;
        const int pathIndex = 2;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (request.Body.Count >= targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal)
            && request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
            _chain?.Handle(request with { PathIndex = pathIndex });

        Next?.Handle(request);
    }

    private class FileShowCommandBuilder : IFileShowCommandBuilder
    {
        private FlagsFileShowSubChainLinkBase? _chain;
        private IContext? _context;

        public IFileShowCommandBuilder WithSubChain(FlagsFileShowSubChainLinkBase chain)
        {
            _chain = chain;
            return this;
        }

        public IFileShowCommandBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public FileShowCommand Create() =>
            new(
                _context ?? throw new BuilderNullException(nameof(FileShowCommandBuilder)),
                _chain);
    }
}