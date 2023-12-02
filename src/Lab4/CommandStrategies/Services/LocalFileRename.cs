using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;

public class LocalFileRename : IStrategy
{
    private readonly IAddressParser _addressParser;

    public LocalFileRename(IAddressParser addressParser)
    {
        _addressParser = addressParser;
    }

    public void Execute(IContext context, IList<string> request)
    {
        const int pathIndex = 0;
        const int newNameIndex = 1;

        string fullPath = _addressParser.GetAbsolutePath(request[pathIndex]);
        string? directory = _addressParser.GetDirectory(fullPath);

        if (directory is null) return;

        if (!File.Exists(fullPath)) return;

        string newFullPath = Path.Combine(directory, request[newNameIndex]);

        if (!File.Exists(newFullPath))
        {
            File.Move(fullPath, newFullPath);
        }
    }
}