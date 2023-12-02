using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;

public class LocalFileDelete : IStrategy
{
    private readonly IAddressParser _addressParser;

    public LocalFileDelete(IAddressParser addressParser)
    {
        _addressParser = addressParser;
    }

    public void Execute(IContext context, IList<string> request)
    {
        const int pathIndex = 0;

        string fullPath = _addressParser.GetAbsolutePath(request[pathIndex]);

        if (File.Exists(fullPath)) File.Delete(fullPath);
    }
}