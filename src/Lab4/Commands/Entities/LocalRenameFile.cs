using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalRenameFile : CommandBase
{
    private IContext? _context;

    public LocalRenameFile()
    {
        Characteristics = new CommandFeatures("file rename", "local", string.Empty);
    }

    public override void Execute(IContext context)
    {
        _context = context;

        if (Request is not null)
        {
            int pathIndex = Request.PathIndex;
            int newNameIndex = pathIndex + NextIndex;

            RenameFile(Request.Body[pathIndex], Request.Body[newNameIndex]);
        }

        Request = null;
    }

    private void RenameFile(string filePath, string newName)
    {
        if (_context is null) return;

        string connectionMode = _context.GetConnectedMode();
        string fullPath = _context.GetAbsoluteAddress(filePath, connectionMode);
        string? directory = Path.GetDirectoryName(fullPath);

        if (directory is null) return;

        if (!File.Exists(fullPath)) return;

        string newFullPath = Path.Combine(directory, newName);

        if (!File.Exists(newFullPath))
        {
            File.Move(fullPath, newFullPath);
        }
    }
}