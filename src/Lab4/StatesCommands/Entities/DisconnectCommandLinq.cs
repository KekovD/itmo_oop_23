using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;

public class DisconnectCommandLinq : CommandChainLinkBase
{
    private readonly FlagsDisconnectSubChainLinqBase? _chain;

    private DisconnectCommandLinq(FlagsDisconnectSubChainLinqBase? chain)
    {
        _chain = chain;
    }

    public static IDisconnectCommandBuilder Builder() => new DisconnectCommandBuilder();

    public override CommandBase? Handle(CommandRequest request)
    {
        const string argument = "disconnect";
        const int argumentIndex = 0;
        const int targetCount = 1;

        if (request.Body.Count >= targetCount &&
            request.Body[argumentIndex].Equals(argument, StringComparison.Ordinal))
        {
            _chain?.Handle(request);

            return new DisconnectCommand(request);
        }

        return Next?.Handle(request);
    }

    private class DisconnectCommandBuilder : IDisconnectCommandBuilder
    {
        private FlagsDisconnectSubChainLinqBase? _chain;

        public IDisconnectCommandBuilder WithSubChain(FlagsDisconnectSubChainLinqBase chain)
        {
            _chain = chain;
            return this;
        }

        public DisconnectCommandLinq Create() => new(_chain);
    }
}