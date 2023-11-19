using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Entities;

public class FileMoveCommand : CommandChainLinkBase
{
    private readonly IContext _context;
    private readonly FlagsFileMoveSubChainLinqBase? _flagsChain;

    private FileMoveCommand(IContext context, FlagsFileMoveSubChainLinqBase? flagsChain)
    {
        _context = context;
        _flagsChain = flagsChain;
    }

    public static IFileMoveCommandBuilder Builder() => new FileMoveCommandBuilder();

    public override CommandBase? Handle(Command request)
    {
        const string firstArgument = "file";
        const string secondArgument = "move";
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
                    new CommandFeatures("file move", connectionMode, string.Empty),
                    request with { PathIndex = pathIndex });
        }

        return Next?.Handle(request);
    }

    private class FileMoveCommandBuilder : IFileMoveCommandBuilder
    {
        private IContext? _context;
        private FlagsFileMoveSubChainLinqBase? _flagsChain;

        public IFileMoveCommandBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public IFileMoveCommandBuilder WithFlagsSubChain(FlagsFileMoveSubChainLinqBase flagsChain)
        {
            _flagsChain = flagsChain;
            return this;
        }

        public FileMoveCommand Create() => new(
            _context ?? throw new BuilderNullException(nameof(FileMoveCommandBuilder)),
            _flagsChain);
    }
}