using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;

public class ConnectedStrategy : IStrategy
{
    private readonly IAddressParser _addressParser;

    public ConnectedStrategy(IAddressParser addressParser)
    {
        _addressParser = addressParser;
    }

    public void Execute(IContext context, IList<string> request)
    {
        const int pathIndex = 0;
        string path = request[pathIndex];

        string absolutePath = _addressParser.GetAbsolutePath(path);
        string? directory = _addressParser.GetDirectory(path);

        if (directory is not null)
            context.TransitionToOtherState(absolutePath, directory);
    }
}