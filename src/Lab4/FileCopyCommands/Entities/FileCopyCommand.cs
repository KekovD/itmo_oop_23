using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Entities;

public class FileCopyCommand : CommandChainLinkBase
{
    private readonly IContext _context;
    private readonly FlagsFileCopySubChainLinqBase? _flagsChain;

    private FileCopyCommand(IContext context, FlagsFileCopySubChainLinqBase? flagsChain)
    {
        _context = context;
        _flagsChain = flagsChain;
    }

    public static IFileCopyCommandBuilder Builder() => new FileCopyCommandBuilder();

    public override CommandBase? Handle(Command request)
    {
        const string firstArgument = "file";
        const string secondArgument = "copy";
        const int targetCount = 4;
        const int firstIndex = 0;
        const int secondIndex = 1;
        const int pathIndex = 2;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (request.Body.Count == targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal) &&
            request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
        {
            _flagsChain?.Handle(request);
            string connectionMode = _context.GetConnectedMode();

            return _context.GetStrategy(connectionMode)?
                .CrateCommand(
                    new CommandFeatures("file copy", connectionMode, string.Empty),
                    request with { PathIndex = pathIndex });
        }

        return Next?.Handle(request);
    }

    private class FileCopyCommandBuilder : IFileCopyCommandBuilder
    {
        private IContext? _context;
        private FlagsFileCopySubChainLinqBase? _flagsChain;

        public IFileCopyCommandBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public IFileCopyCommandBuilder WithFlagsSubChain(FlagsFileCopySubChainLinqBase flagsChain)
        {
            _flagsChain = flagsChain;
            return this;
        }

        public FileCopyCommand Create() => new(
            _context ?? throw new BuilderNullException(nameof(FileCopyCommandBuilder)),
            _flagsChain);
    }
}