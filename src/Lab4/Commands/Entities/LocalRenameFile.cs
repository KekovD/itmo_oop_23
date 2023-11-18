using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalRenameFile : ICommand
{
    private readonly IContext _context;

    public LocalRenameFile(IContext context)
    {
        _context = context;
    }

    public void Execute(Command request)
    {
        const int pathIndex = 2;
        const int newNameIndex = 3;
        RenameFile(request.Body[pathIndex], request.Body[newNameIndex]);
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
}