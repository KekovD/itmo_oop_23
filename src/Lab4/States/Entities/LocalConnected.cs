using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

public class LocalConnected : FlagsConnectSubChainLinqBase
{
    private readonly IContext _context;

    private LocalConnected(IContext context)
    {
        _context = context;
    }

    public static ILocalConnectedBuilder Builder() => new LocalConnectedBuilder();

    public override void Handle(Command request)
    {
        const int targetCount = 2;
        const string targetValue = "-m";
        const string targetParameter = "local";

        if (request.Body.Count != targetCount)
            Next?.Handle(request);

        if (request.Flags.Any(flag => flag.Value.Equals(targetValue, StringComparison.Ordinal) &&
                                      flag.Parameter.Equals(targetParameter, StringComparison.Ordinal)))
            _context.TransitionToOtherState(request);

        Next?.Handle(request);
    }

    private class LocalConnectedBuilder : ILocalConnectedBuilder
    {
        private IContext? _context;

        public ILocalConnectedBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public LocalConnected Crate() => new(
            _context ?? throw new BuilderNullException(nameof(LocalConnectedBuilder)));
    }
}