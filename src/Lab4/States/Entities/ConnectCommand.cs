using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

public class ConnectCommand : CommandChainLinkBase
{
    private readonly IContext _context;
    private readonly FlagsConnectSubChainLinqBase _chain;

    private ConnectCommand(FlagsConnectSubChainLinqBase chain, IContext context)
    {
        _chain = chain;
        _context = context;
    }

    public static IConnectCommandBuilder Builder() => new ConnectCommandBuilder();

    public override void Handle(Command request)
    {
        const string argument = "connect";
        const int argumentIndex = 0;
        const int targetCount = 1;

        if (_context.ConnectRequest()) Next?.Handle(request);

        if (request.Body.Count >= targetCount &&
            request.Body[argumentIndex].Equals(argument, StringComparison.Ordinal))
            _chain.Handle(request);

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

        public ConnectCommand Crate() =>
            new(
                _chain ?? throw new BuilderNullException(nameof(ConnectCommandBuilder)),
                _context ?? throw new BuilderNullException(nameof(ConnectCommandBuilder)));
    }
}