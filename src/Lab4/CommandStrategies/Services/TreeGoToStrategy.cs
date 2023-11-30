using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Services;

public class TreeGoToStrategy : IStrategy
{
    private readonly IAddressParser _addressParser;

    public TreeGoToStrategy(IAddressParser addressParser)
    {
        _addressParser = addressParser;
    }

    public void Execute(IContext context, IList<string> request)
    {
        const int pathIndex = 0;

        string path = _addressParser.GetAbsolutePath(request[pathIndex]);
        string? drive = _addressParser.GetDirectory(path);

        if (drive is not null)
            context.TransitionToOtherAddress(path, drive);
    }
}