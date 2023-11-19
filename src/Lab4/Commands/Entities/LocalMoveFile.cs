using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalMoveFile : CommandBase
{
    private IContext? _context;

    public LocalMoveFile()
    {
        Characteristics = new CommandFeatures("file move", "local", string.Empty);
    }

    public override void Execute(IContext context)
    {
        _context = context;

        if (Request is not null)
        {
            int sourceIndex = Request.PathIndex;
            int destinationIndex = sourceIndex + NextIndex;

            MoveFile(Request.Body[sourceIndex], Request.Body[destinationIndex]);
        }

        Request = null;
    }

    private void MoveFile(string sourcePath, string destinationPath)
    {
        if (_context is null) return;

        string connectionMode = _context.GetConnectedMode();
        string sourceFullPath = _context.GetAbsoluteAddress(sourcePath, connectionMode);
        string destinationDir = _context.GetAbsoluteAddress(destinationPath, connectionMode);

        if (!File.Exists(sourceFullPath)) return;

        string fileName = Path.GetFileName(sourceFullPath);
        string destinationFullPath = Path.Combine(destinationDir, fileName);

        if (File.Exists(destinationFullPath))
        {
            destinationFullPath = Path.Combine(
                destinationDir,
                _context.GetUniqueFileName(destinationDir, fileName, connectionMode));
        }

        File.Move(sourceFullPath, destinationFullPath);
    }
}