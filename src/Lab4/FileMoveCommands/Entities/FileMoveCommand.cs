using System;
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
    private readonly MoveFileSystemSubChainLinqBase _fileSystemChain;

    private FileMoveCommand(IContext context, MoveFileSystemSubChainLinqBase fileSystemChain, FlagsFileMoveSubChainLinqBase? flagsChain)
    {
        _context = context;
        _fileSystemChain = fileSystemChain;
        _flagsChain = flagsChain;
    }

    public static IFileMoveCommandBuilder Builder() => new FileMoveCommandBuilder();

    public override void Handle(Command request)
    {
        const string firstArgument = "file";
        const string secondArgument = "move";
        const int targetCount = 4;
        const int firstIndex = 0;
        const int secondIndex = 1;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (request.Body.Count >= targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal) &&
            request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
        {
            _flagsChain?.Handle(request);
            _fileSystemChain.Handle(request);
        }

        Next?.Handle(request);
    }

    private class FileMoveCommandBuilder : IFileMoveCommandBuilder
    {
        private IContext? _context;
        private FlagsFileMoveSubChainLinqBase? _flagsChain;
        private MoveFileSystemSubChainLinqBase? _fileSystemChain;

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

        public IFileMoveCommandBuilder WithFileSystemSubChain(MoveFileSystemSubChainLinqBase fileSystemChain)
        {
            _fileSystemChain = fileSystemChain;
            return this;
        }

        public FileMoveCommand Crate() => new(
            _context ?? throw new BuilderNullException(nameof(FileMoveCommandBuilder)),
            _fileSystemChain ?? throw new BuilderNullException(nameof(FileMoveCommandBuilder)),
            _flagsChain);
    }
}