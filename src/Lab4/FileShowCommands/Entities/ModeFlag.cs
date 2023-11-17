using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;

public class ModeFlag : FlagsFileShowSubChainLinkBase
{
    private readonly ModeFlagSubChainLinkBase? _chain;
    private readonly IContext _context;

    private ModeFlag(IContext context, ModeFlagSubChainLinkBase? chain)
    {
        _context = context;
        _chain = chain;
    }

    public static IModeFlagBuilder Builder() => new ModeFlagBuilder();

    public override void Handle(Command request)
    {
        if (_context.DisconnectRequest()) Next?.Handle(request);

        const string targetValue = "-m";

        if (request.Flags.Any(flag => flag.Value.Equals(targetValue, StringComparison.Ordinal)))
            _chain?.Handle(request);

        Next?.Handle(request);
    }

    private class ModeFlagBuilder : IModeFlagBuilder
    {
        private ModeFlagSubChainLinkBase? _chain;
        private IContext? _context;

        public IModeFlagBuilder WithSubChain(ModeFlagSubChainLinkBase chain)
        {
            _chain = chain;
            return this;
        }

        public IModeFlagBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public ModeFlag Create() => new(
            _context ?? throw new BuilderNullException(nameof(ModeFlagBuilder)),
            _chain);
    }
}