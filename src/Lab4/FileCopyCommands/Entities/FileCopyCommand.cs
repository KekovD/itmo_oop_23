using System;
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
    private readonly CopyFileSystemSubChainLinqBase? _fileSystemChain;

    private FileCopyCommand(IContext context, CopyFileSystemSubChainLinqBase? fileSystemChain, FlagsFileCopySubChainLinqBase? flagsChain)
    {
        _context = context;
        _fileSystemChain = fileSystemChain;
        _flagsChain = flagsChain;
    }

    public static IFileCopyCommandBuilder Builder() => new FileCopyCommandBuilder();

    public override void Handle(Command request)
    {
        const string firstArgument = "file";
        const string secondArgument = "copy";
        const int targetCount = 4;
        const int firstIndex = 0;
        const int secondIndex = 1;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (request.Body.Count >= targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal) &&
            request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
        {
            _flagsChain?.Handle(request);
            _fileSystemChain?.Handle(request);
        }

        Next?.Handle(request);
    }

    private class FileCopyCommandBuilder : IFileCopyCommandBuilder
    {
        private IContext? _context;
        private FlagsFileCopySubChainLinqBase? _flagsChain;
        private CopyFileSystemSubChainLinqBase? _fileSystemChain;

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

        public IFileCopyCommandBuilder WithFileSystemSubChain(CopyFileSystemSubChainLinqBase fileSystemChain)
        {
            _fileSystemChain = fileSystemChain;
            return this;
        }

        public FileCopyCommand Create() => new(
            _context ?? throw new BuilderNullException(nameof(FileCopyCommandBuilder)),
            _fileSystemChain,
            _flagsChain);
    }
}