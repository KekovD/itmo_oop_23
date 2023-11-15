using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

public class DisconnectCommand : CommandChainLinkBase
{
    private readonly IContext _context;

    private DisconnectCommand(IContext context, FlagsDisconnectSubChainLinqBase? chain)
    {
        _context = context;
        Chain = chain;
    }

    public FlagsDisconnectSubChainLinqBase? Chain { get; }

    public static IDisconnectCommandBuilder Builder() => new DisconnectCommandBuilder();

    public override void Handle(Command request)
    {
        const string argument = "disconnect";
        const int argumentIndex = 0;
        const int targetCount = 1;

        if (request.Body.Count >= targetCount &&
            request.Body[argumentIndex].Equals(argument, StringComparison.Ordinal) &&
            _context.ConnectRequest())
        {
            Chain?.Handle(request);
            _context.Transition(request);
        }

        Next?.Handle(request);
    }

    private class DisconnectCommandBuilder : IDisconnectCommandBuilder
    {
        private FlagsDisconnectSubChainLinqBase? _chain;
        private IContext? _context;

        public IDisconnectCommandBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public IDisconnectCommandBuilder WithChain(FlagsDisconnectSubChainLinqBase chain)
        {
            _chain = chain;
            return this;
        }

        public DisconnectCommand Crate() => new(
            _context ?? throw new BuilderNullException(nameof(DisconnectCommandBuilder)),
            _chain);
    }
}