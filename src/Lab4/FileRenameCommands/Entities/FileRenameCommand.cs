using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Entities;

public class FileRenameCommand : CommandChainLinkBase
{
    private readonly IContext _context;
    private readonly FlagsFileRenameSubChainLinqBase? _flagsChain;

    private FileRenameCommand(IContext context, FlagsFileRenameSubChainLinqBase? flagsChain)
    {
        _context = context;
        _flagsChain = flagsChain;
    }

    public static IFileRenameCommandBuilder Builder() => new FileRenameCommandBuilder();

    public override CommandBase? Handle(Command request)
    {
        const string firstArgument = "file";
        const string secondArgument = "rename";
        const int targetCount = 4;
        const int firstIndex = 0;
        const int secondIndex = 1;
        const int pathIndex = 2;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (request.Body.Count >= targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal) &&
            request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
        {
            _flagsChain?.Handle(request with { PathIndex = pathIndex });
            string connectionMode = _context.GetConnectedMode();

            return _context.GetStrategy(connectionMode)?
                .CrateCommand(
                    new CommandFeatures("file rename", connectionMode, string.Empty),
                    request with { PathIndex = pathIndex });
        }

        return Next?.Handle(request);
    }

    private class FileRenameCommandBuilder : IFileRenameCommandBuilder
    {
        private IContext? _context;
        private FlagsFileRenameSubChainLinqBase? _flagsChain;

        public IFileRenameCommandBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public IFileRenameCommandBuilder WithFlagsSubChain(FlagsFileRenameSubChainLinqBase flagsChain)
        {
            _flagsChain = flagsChain;
            return this;
        }

        public FileRenameCommand Create() => new(
            _context ?? throw new BuilderNullException(nameof(FileRenameCommandBuilder)),
            _flagsChain);
    }
}