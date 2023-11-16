using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

public class DepthFlag : FlagsTreeListSubChainLinqBase
{
    private readonly IContext _context;
    private readonly DepthFlagSubChainLinqBase _chain;

    private DepthFlag(IContext context, DepthFlagSubChainLinqBase chain)
    {
        _context = context;
        _chain = chain;
    }

    public static IDepthFlagBuilder Builder() => new DepthFlagBuilder();
    public override void Handle(Command request)
    {
        if (_context.ConnectRequest())
            _chain.Handle(request);

        Next?.Handle(request);
    }

    private class DepthFlagBuilder : IDepthFlagBuilder
    {
        private IContext? _context;
        private DepthFlagSubChainLinqBase? _chain;

        public IDepthFlagBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public IDepthFlagBuilder WithSubChain(DepthFlagSubChainLinqBase chain)
        {
            _chain = chain;
            return this;
        }

        public DepthFlag Crate() => new(
            _context ?? throw new BuilderNullException(nameof(DepthFlagBuilder)),
            _chain ?? throw new BuilderNullException(nameof(DepthFlagBuilder)));
    }
}