using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;

public class ModeFlag : FlagsFileShowSubChainLinkBase
{
    public override CommandBase? Handle(CommandRequest request)
    {
        const string targetValue = "-m";
        const int pathIndex = 2;

        Flag? foundFlag =
            request.Flags.FirstOrDefault(flag => flag.Value.Equals(targetValue, StringComparison.Ordinal));

        if (foundFlag is not null)
        {
            return new FileShowCommand(request with { PathIndex = pathIndex });
        }

        return Next?.Handle(request);
    }
}