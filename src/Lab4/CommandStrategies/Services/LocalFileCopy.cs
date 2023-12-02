using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;

public class LocalFileCopy : IStrategy
{
    private readonly IAddressParser _addressParser;

    public LocalFileCopy(IAddressParser addressParser)
    {
        _addressParser = addressParser;
    }

    public void Execute(IContext context, IList<string> request)
    {
        const int sourceIndex = 0;
        const int destinationIndex = 1;

        string sourceFullPath = _addressParser.GetAbsolutePath(request[sourceIndex]);
        string destinationDir = _addressParser.GetAbsolutePath(request[destinationIndex]);

        if (!File.Exists(sourceFullPath)) return;

        string fileName = Path.GetFileName(sourceFullPath);
        string destinationFullPath = Path.Combine(destinationDir, fileName);

        if (File.Exists(destinationFullPath))
        {
            destinationFullPath = Path.Combine(
                destinationDir,
                _addressParser.GetUniqueName(destinationDir, fileName));
        }

        File.Copy(sourceFullPath, destinationFullPath);
    }
}