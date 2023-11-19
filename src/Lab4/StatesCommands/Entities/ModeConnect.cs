using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;

public class ModeConnect : FlagsConnectSubChainLinqBase
{
    private readonly IContext _context;

    private ModeConnect(IContext context)
    {
        _context = context;
    }

    public static ILocalConnectedBuilder Builder() => new LocalConnectedBuilder();

    public override CommandBase? Handle(Command request)
    {
        const int targetCount = 2;

        if (request.Body.Count != targetCount || _context.ConnectRequest())
            return Next?.Handle(request);

        const string targetValue = "-m";

        Flag? foundFlag =
            request.Flags.FirstOrDefault(flag => flag.Value.Equals(targetValue, StringComparison.Ordinal));

        if (foundFlag is not null)
        {
            string connectionMode = foundFlag.Parameter;
            const int pathIndex = 1;

            return _context.GetStrategy(connectionMode)?
                .CrateCommand(
                    new CommandFeatures("connect", connectionMode, string.Empty),
                    request with { PathIndex = pathIndex });
        }

        return Next?.Handle(request);
    }

    private class LocalConnectedBuilder : ILocalConnectedBuilder
    {
        private IContext? _context;

        public ILocalConnectedBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public ModeConnect Create() => new(
            _context ?? throw new BuilderNullException(nameof(LocalConnectedBuilder)));
    }
}