﻿using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Entities;

public class FileDeleteCommand : CommandChainLinkBase
{
    private readonly IContext _context;
    private readonly FlagsFileDeleteSubChainLinqBase? _flagsChain;
    private readonly DeleteFileSystemSubChainLinqBase _fileSystemChain;

    private FileDeleteCommand(IContext context, DeleteFileSystemSubChainLinqBase fileSystemChain, FlagsFileDeleteSubChainLinqBase? flagsChain)
    {
        _context = context;
        _fileSystemChain = fileSystemChain;
        _flagsChain = flagsChain;
    }

    public static IFileDeleteCommandBuilder Builder() => new FileDeleteCommandBuilder();

    public override void Handle(Command request)
    {
        const string firstArgument = "file";
        const string secondArgument = "delete";
        const int targetCount = 3;
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

    private class FileDeleteCommandBuilder : IFileDeleteCommandBuilder
    {
        private IContext? _context;
        private FlagsFileDeleteSubChainLinqBase? _flagsChain;
        private DeleteFileSystemSubChainLinqBase? _fileSystemChain;

        public IFileDeleteCommandBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public IFileDeleteCommandBuilder WithFlagsSubChain(FlagsFileDeleteSubChainLinqBase flagsChain)
        {
            _flagsChain = flagsChain;
            return this;
        }

        public IFileDeleteCommandBuilder WithFileSystemSubChain(DeleteFileSystemSubChainLinqBase fileSystemChain)
        {
            _fileSystemChain = fileSystemChain;
            return this;
        }

        public FileDeleteCommand Crate() => new(
            _context ?? throw new BuilderNullException(nameof(FileDeleteCommandBuilder)),
            _fileSystemChain ?? throw new BuilderNullException(nameof(FileDeleteCommandBuilder)),
            _flagsChain);
    }
}