using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalDeleteFile : CommandBase
{
    private IContext? _context;

    public LocalDeleteFile()
    {
        Characteristics = new CommandFeatures("file delete", "local", string.Empty);
    }

    public override void Execute(Command request, IContext context)
    {
        _context = context;

        DeleteFile(request.Body[request.PathIndex]);
    }

    private void DeleteFile(string filePath)
    {
        if (_context is null) return;

        string fullPath = _context.GetAbsoluteAddress(filePath, _context.GetConnectedMode());

        if (File.Exists(fullPath)) File.Delete(fullPath);
    }
}