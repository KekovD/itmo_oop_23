using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

public class TreeGoToCommand : CommandChainLinkBase
{
    private readonly IContext _context;

    private TreeGoToCommand(IContext context, FlagsTreeGoToSubChainLinqBase? chain)
    {
        _context = context;
        Chain = chain;
    }

    public FlagsTreeGoToSubChainLinqBase? Chain { get; }

    public static ITreeGoToCommandBuilder Builder() => new TreeGoToCommandBuilder();

    public override void Handle(Command request)
    {
        const int targetCount = 3;
        const int firstValueIndex = 0;
        const int secondValueIndex = 1;
        const string firstValue = "tree";
        const string secondValue = "goto";

        if (request.Body.Count == targetCount &&
            request.Body[firstValueIndex].Equals(firstValue, StringComparison.Ordinal) &&
            request.Body[secondValueIndex].Equals(secondValue, StringComparison.Ordinal) &&
            _context.ConnectRequest())
        {
            Chain?.Handle(request);
            _context.TransitionToOtherAddress(request);
        }

        Next?.Handle(request);
    }

    private class TreeGoToCommandBuilder : ITreeGoToCommandBuilder
    {
        private IContext? _context;
        private FlagsTreeGoToSubChainLinqBase? _chain;

        public ITreeGoToCommandBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public ITreeGoToCommandBuilder WithChain(FlagsTreeGoToSubChainLinqBase chain)
        {
            _chain = chain;
            return this;
        }

        public TreeGoToCommand Crate() => new(
            _context ?? throw new BuilderNullException(nameof(TreeGoToCommandBuilder)),
            _chain);
    }
}