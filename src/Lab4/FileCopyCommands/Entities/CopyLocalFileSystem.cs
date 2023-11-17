using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Entities;

public class CopyLocalFileSystem : CopyFileSystemSubChainLinqBase
{
    private readonly IContext _context;

    private CopyLocalFileSystem(IContext context)
    {
        _context = context;
    }

    public static ICopyLocalFileSystemBuilder Builder() => new CopyLocalFileSystemBuilder();

    public override void Handle(Command request)
    {
        const string targetMode = "local";
        const int targetCount = 4;
        const int sourceIndex = 2;
        const int destinationIndex = 3;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (_context.CheckConnectedMode(targetMode) &&
            request.Body.Count == targetCount)
            CopyFile(request.Body[sourceIndex], request.Body[destinationIndex]);

        Next?.Handle(request);
    }

    private void CopyFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = _context.GetAbsoluteAddress(sourcePath);
        string destinationDir = _context.GetAbsoluteAddress(destinationPath);

        if (!File.Exists(sourceFullPath)) return;

        string fileName = Path.GetFileName(sourceFullPath);
        string destinationFullPath = Path.Combine(destinationDir, fileName);

        if (File.Exists(destinationFullPath))
            destinationFullPath = Path.Combine(destinationDir, _context.GetUniqueFileName(destinationDir, fileName));

        File.Copy(sourceFullPath, destinationFullPath);
    }

    private class CopyLocalFileSystemBuilder : ICopyLocalFileSystemBuilder
    {
        private IContext? _context;

        public ICopyLocalFileSystemBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public CopyLocalFileSystem Create() =>
            new(_context ?? throw new BuilderNullException(nameof(CopyLocalFileSystemBuilder)));
    }
}