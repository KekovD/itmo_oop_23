using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalMoveFile : ICommand
{
    private readonly IContext _context;

    public LocalMoveFile(IContext context)
    {
        _context = context;
    }

    public void Execute(Command request)
    {
        const int sourceIndex = 2;
        const int destinationIndex = 3;
        MoveFile(request.Body[sourceIndex], request.Body[destinationIndex]);
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
}