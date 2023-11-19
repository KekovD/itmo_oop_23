using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalMoveFile : CommandBase
{
    private IContext? _context;

    public LocalMoveFile()
    {
        Characteristics = new CommandFeatures("file move", "local", string.Empty);
    }

    public override void Execute(Command request, IContext context)
    {
        _context = context;

        int sourceIndex = request.PathIndex;
        int destinationIndex = sourceIndex + NextIndex;

        MoveFile(request.Body[sourceIndex], request.Body[destinationIndex]);
    }

    private void MoveFile(string sourcePath, string destinationPath)
    {
        if (_context is null) return;

        string sourceFullPath = _context.GetAbsoluteAddress(sourcePath);
        string destinationDir = _context.GetAbsoluteAddress(destinationPath);

        if (!File.Exists(sourceFullPath)) return;

        string fileName = Path.GetFileName(sourceFullPath);
        string destinationFullPath = Path.Combine(destinationDir, fileName);

        if (File.Exists(destinationFullPath))
            destinationFullPath = Path.Combine(destinationDir, _context.GetUniqueFileName(destinationDir, fileName));

        File.Move(sourceFullPath, destinationFullPath);
    }
}