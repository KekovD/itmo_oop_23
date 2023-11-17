using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;

public class ConnectCommand : CommandChainLinkBase
{
    private readonly IContext _context;
    private readonly FlagsConnectSubChainLinqBase? _chain;

    private ConnectCommand(IContext context, FlagsConnectSubChainLinqBase? chain)
    {
        _context = context;
        _chain = chain;
    }

    public static IConnectCommandBuilder Builder() => new ConnectCommandBuilder();

    public override void Handle(Command request)
    {
        const string argument = "connect";
        const int argumentIndex = 0;
        const int pathIndex = 1;
        const int targetCount = 1;

        if (_context.ConnectRequest()) Next?.Handle(request);

        if (request.Body.Count >= targetCount &&
            request.Body[argumentIndex].Equals(argument, StringComparison.Ordinal))
            _chain?.Handle(request with { PathIndex = pathIndex });

        Next?.Handle(request);
    }

    private class ConnectCommandBuilder : IConnectCommandBuilder
    {
        private FlagsConnectSubChainLinqBase? _chain;
        private IContext? _context;

        public IConnectCommandBuilder WithSubChain(FlagsConnectSubChainLinqBase chain)
        {
            _chain = chain;
            return this;
        }

        public IConnectCommandBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public ConnectCommand Create() =>
            new(
                _context ?? throw new BuilderNullException(nameof(ConnectCommandBuilder)),
                _chain);
    }
}