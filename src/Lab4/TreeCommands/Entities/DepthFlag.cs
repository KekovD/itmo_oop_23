using System;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

public class DepthFlag : FlagsTreeListSubChainLinqBase
{
    public override CommandBase? Handle(CommandRequest request)
    {
        const string depthValue = "-d";

        Flag? depthFlag =
            request.Flags.FirstOrDefault(flag => flag.Value.Equals(depthValue, StringComparison.Ordinal));

        const string modeValue = "-m";

        Flag? modeFlag =
            request.Flags.FirstOrDefault(flag => flag.Value.Equals(modeValue, StringComparison.Ordinal));

        if (modeFlag is not null)
        {
            int depth = 1;

            if (depthFlag is not null)
                int.TryParse(depthFlag.Parameter, NumberStyles.Integer, CultureInfo.InvariantCulture, out depth);

            return new TreeListCommand(request with { PathIndex = depth });
        }

        return Next?.Handle(request);
    }
}