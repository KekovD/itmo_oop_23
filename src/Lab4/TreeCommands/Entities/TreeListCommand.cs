using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

public class TreeListCommand : CommandChainLinkBase
{
    private readonly IContext _context;
    private readonly FlagsTreeListSubChainLinqBase _chain;

    private TreeListCommand(IContext context, FlagsTreeListSubChainLinqBase chain)
    {
        _context = context;
        _chain = chain;
    }

    public static ITreeListCommandBuilder Builder() => new TreeListCommandBuilder();

    public override void Handle(Command request)
    {
        const int targetCount = 3;
        const int firstValueIndex = 0;
        const int secondValueIndex = 1;
        const string firstValue = "tree";
        const string secondValue = "list";

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (request.Body.Count >= targetCount &&
            request.Body[firstValueIndex].Equals(firstValue, StringComparison.Ordinal) &&
            request.Body[secondValueIndex].Equals(secondValue, StringComparison.Ordinal))
            _chain.Handle(request);

        Next?.Handle(request);
    }

    private class TreeListCommandBuilder : ITreeListCommandBuilder
    {
        private IContext? _context;
        private FlagsTreeListSubChainLinqBase? _chain;

        public ITreeListCommandBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public ITreeListCommandBuilder WithSubChain(FlagsTreeListSubChainLinqBase chain)
        {
            _chain = chain;
            return this;
        }

        public TreeListCommand Crate() => new(
            _context ?? throw new BuilderNullException(nameof(TreeListCommandBuilder)),
            _chain ?? throw new BuilderNullException(nameof(TreeListCommandBuilder)));
    }
}