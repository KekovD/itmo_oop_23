using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Entities;

public class MoveLocalFileSystem : MoveFileSystemSubChainLinqBase
{
    private readonly IContext _context;

    private MoveLocalFileSystem(IContext context)
    {
        _context = context;
    }

    public static IMoveLocalFileSystemBuilder Builder() => new MoveLocalFileSystemBuilder();

    public override void Handle(Command request)
    {
        const string targetMode = "local";
        const int targetCount = 4;
        const int sourceIndex = 2;
        const int destinationIndex = 3;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (_context.CheckConnectedMode(targetMode) &&
            request.Body.Count == targetCount)
            MoveFile(request.Body[sourceIndex], request.Body[destinationIndex]);

        Next?.Handle(request);
    }

    private void MoveFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = _context.GetAbsoluteAddress(sourcePath);
        string destinationDir = _context.GetAbsoluteAddress(destinationPath);

        if (!File.Exists(sourceFullPath)) return;

        string fileName = Path.GetFileName(sourceFullPath);
        string destinationFullPath = Path.Combine(destinationDir, fileName);

        if (File.Exists(destinationFullPath))
            destinationFullPath = Path.Combine(destinationDir, _context.GetUniqueFileName(destinationDir, fileName));

        File.Move(sourceFullPath, destinationFullPath);
    }

    private class MoveLocalFileSystemBuilder : IMoveLocalFileSystemBuilder
    {
        private IContext? _context;

        public IMoveLocalFileSystemBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public MoveLocalFileSystem Create() =>
            new(_context ?? throw new BuilderNullException(nameof(MoveLocalFileSystemBuilder)));
    }
}