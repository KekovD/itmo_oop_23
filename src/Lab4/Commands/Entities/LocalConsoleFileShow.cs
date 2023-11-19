using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalConsoleFileShow : CommandBase
{
    private IContext? _context;

    public LocalConsoleFileShow()
    {
        Characteristics = new CommandFeatures("file show", "local", "console");
    }

    public override void Execute(Command request, IContext context)
    {
        _context = context;

        const int pathIndex = 2;

        FileConsoleRender(request.Body[pathIndex]);
    }

    private void FileConsoleRender(string filePath)
    {
        if (_context is null) return;

        string absolutePath = Path.GetFullPath(filePath);

        if (!File.Exists(absolutePath))
        {
            string newPath = Path.Combine(
                _context.Drive ?? throw new ContextNullException(nameof(FileConsoleRender)),
                Path.GetFileName(filePath));

            if (File.Exists(newPath))
            {
                absolutePath = newPath;
            }
            else
            {
                Console.WriteLine("File not found.");
                return;
            }
        }

        string content = File.ReadAllText(absolutePath);
        Console.WriteLine(content);
    }
}