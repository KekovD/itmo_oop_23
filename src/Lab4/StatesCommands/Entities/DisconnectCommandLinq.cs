﻿using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;

public class DisconnectCommandLinq : CommandChainLinkBase
{
    private readonly IContext _context;
    private readonly FlagsDisconnectSubChainLinqBase? _chain;

    private DisconnectCommandLinq(IContext context, FlagsDisconnectSubChainLinqBase? chain)
    {
        _context = context;
        _chain = chain;
    }

    public static IDisconnectCommandBuilder Builder() => new DisconnectCommandBuilder();

    public override CommandBase? Handle(Command request)
    {
        const string argument = "disconnect";
        const int argumentIndex = 0;
        const int targetCount = 1;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (request.Body.Count >= targetCount &&
            request.Body[argumentIndex].Equals(argument, StringComparison.Ordinal))
        {
            _chain?.Handle(request);

            return _context.GetStrategy(_context.GetConnectedMode())?
                .CrateCommand(
                    new CommandFeatures("disconnect", string.Empty, string.Empty),
                    request);
        }

        return Next?.Handle(request);
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

        public IDisconnectCommandBuilder WithSubChain(FlagsDisconnectSubChainLinqBase chain)
        {
            _chain = chain;
            return this;
        }

        public DisconnectCommandLinq Create() => new(
            _context ?? throw new BuilderNullException(nameof(DisconnectCommandBuilder)),
            _chain);
    }
}