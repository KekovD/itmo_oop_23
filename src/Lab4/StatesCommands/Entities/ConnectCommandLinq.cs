using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;

public class ConnectCommandLinq : CommandChainLinkBase
{
    private readonly FlagsConnectSubChainLinqBase? _chain;

    private ConnectCommandLinq(FlagsConnectSubChainLinqBase? chain)
    {
        _chain = chain;
    }

    public static IConnectCommandBuilder Builder() => new ConnectCommandBuilder();

    public override CommandBase? Handle(CommandRequest request)
    {
        const string argument = "connect";
        const int argumentIndex = 0;
        const int targetCount = 2;

        if (request.Body.Count == targetCount &&
            request.Body[argumentIndex].Equals(argument, StringComparison.Ordinal))
            return _chain?.Handle(request);

        return Next?.Handle(request);
    }

    private class ConnectCommandBuilder : IConnectCommandBuilder
    {
        private FlagsConnectSubChainLinqBase? _chain;

        public IConnectCommandBuilder WithSubChain(FlagsConnectSubChainLinqBase chain)
        {
            _chain = chain;
            return this;
        }

        public ConnectCommandLinq Create() => new(_chain);
    }
}