using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;

public class ModeFlag : FlagsFileShowSubChainLinkBase
{
    private readonly IContext _context;

    private ModeFlag(IContext context)
    {
        _context = context;
    }

    public static IModeFlagBuilder Builder() => new ModeFlagBuilder();

    public override CommandBase? Handle(Command request)
    {
        if (_context.DisconnectRequest()) Next?.Handle(request);

        const string targetValue = "-m";

        Flag? foundFlag =
            request.Flags.FirstOrDefault(flag => flag.Value.Equals(targetValue, StringComparison.Ordinal));

        if (foundFlag is not null)
        {
            string connectionMode = _context.GetConnectedMode();

            return _context.GetStrategy(connectionMode)?
                .CrateCommand(
                    new CommandFeatures("file show", connectionMode, foundFlag.Parameter),
                    request);
        }

        return Next?.Handle(request);
    }

    private class ModeFlagBuilder : IModeFlagBuilder
    {
        private IContext? _context;

        public IModeFlagBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public ModeFlag Create() => new(_context ?? throw new BuilderNullException(nameof(ModeFlagBuilder)));
    }
}