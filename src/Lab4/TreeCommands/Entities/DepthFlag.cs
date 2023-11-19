using System;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

public class DepthFlag : FlagsTreeListSubChainLinqBase
{
    private readonly IContext _context;

    private DepthFlag(IContext context)
    {
        _context = context;
    }

    public static IDepthFlagBuilder Builder() => new DepthFlagBuilder();
    public override CommandBase? Handle(Command request)
    {
        const string depthValue = "-d";

        Flag? depthFlag =
            request.Flags.FirstOrDefault(flag => flag.Value.Equals(depthValue, StringComparison.Ordinal));

        const string modeValue = "-m";

        Flag? modeFlag =
            request.Flags.FirstOrDefault(flag => flag.Value.Equals(modeValue, StringComparison.Ordinal));

        if (modeFlag is not null)
        {
            string connectionMode = _context.GetConnectedMode();

            int depth = depthFlag is not null ? int.Parse(depthFlag.Parameter, CultureInfo.InvariantCulture) : 1;

            return _context.GetStrategy(connectionMode)?
                .CrateCommand(
                    new CommandFeatures("tree list", connectionMode, modeFlag.Parameter),
                    request with { PathIndex = depth });
        }

        return Next?.Handle(request);
    }

    private class DepthFlagBuilder : IDepthFlagBuilder
    {
        private IContext? _context;

        public IDepthFlagBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public DepthFlag Create() => new(_context ?? throw new BuilderNullException(nameof(DepthFlagBuilder)));
    }
}