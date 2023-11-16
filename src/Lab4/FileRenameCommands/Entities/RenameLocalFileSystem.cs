using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Entities;

public class RenameLocalFileSystem : RenameFileSystemSubChainLinqBase
{
    private readonly IContext _context;

    private RenameLocalFileSystem(IContext context)
    {
        _context = context;
    }

    public override void Handle(Command request)
    {
        const string targetMode = "local";
        const int targetCount = 4;
        const int pathIndex = 2;
        const int newNameIndex = 3;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (_context.CheckConnectedMode(targetMode) &&
            request.Body.Count == targetCount)
            RenameFile(request.Body[pathIndex], request.Body[newNameIndex]);

        Next?.Handle(request);
    }

    private void RenameFile(string filePath, string newName)
    {
        string fullPath = _context.GetAbsoluteAddress(filePath);

        string? directory = Path.GetDirectoryName(fullPath);

        if (directory is null) return;

        if (!File.Exists(fullPath)) return;

        string newFullPath = Path.Combine(directory, newName);

        if (!File.Exists(newFullPath))
        {
            File.Move(fullPath, newFullPath);
        }
    }

    private class RenameLocalFileSystemBuilder : IRenameLocalFileSystemBuilder
    {
        private IContext? _context;

        public IRenameLocalFileSystemBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public RenameLocalFileSystem Crate() =>
            new(_context ?? throw new BuilderNullException(nameof(RenameLocalFileSystemBuilder)));
    }
}