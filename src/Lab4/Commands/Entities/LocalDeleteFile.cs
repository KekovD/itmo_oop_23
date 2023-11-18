using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalDeleteFile : ICommand
{
    private readonly IContext _context;

    public LocalDeleteFile(IContext context)
    {
        _context = context;
    }

    public void Execute(Command request)
    {
        const int pathIndex = 2;
        DeleteFile(request.Body[pathIndex]);
    }

    private void DeleteFile(string filePath)
    {
        string fullPath = _context.GetAbsoluteAddress(filePath);

        if (File.Exists(fullPath)) File.Delete(fullPath);
    }
}