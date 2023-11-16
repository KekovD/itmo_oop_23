using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Renderables.Models;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderables.Entities;

public class FileShowCommand : CommandChainLinkBase
{
    private readonly IContext _context;
    private readonly FlagsFileShowSubChainLinkBase _chain;

    private FileShowCommand(FlagsFileShowSubChainLinkBase first, IContext context)
    {
        _chain = first;
        _context = context;
    }

    public static IFileShowCommandBuilder Builder() => new FileShowCommandBuilder();

    public override void Handle(Command request)
    {
        const string firstArgument = "file";
        const string secondArgument = "show";
        const int targetCount = 2;
        const int firstIndex = 0;
        const int secondIndex = 1;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (request.Body.Count >= targetCount &&
            request.Body[firstIndex].Equals(firstArgument, StringComparison.Ordinal)
            && request.Body[secondIndex].Equals(secondArgument, StringComparison.Ordinal))
            _chain.Handle(request);

        Next?.Handle(request);
    }

    private class FileShowCommandBuilder : IFileShowCommandBuilder
    {
        private FlagsFileShowSubChainLinkBase? _chain;
        private IContext? _context;

        public IFileShowCommandBuilder WithSubChain(FlagsFileShowSubChainLinkBase chain)
        {
            _chain = chain;
            return this;
        }

        public IFileShowCommandBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public FileShowCommand Crate() =>
            new(
                _chain ?? throw new BuilderNullException(nameof(FileShowCommandBuilder)),
                _context ?? throw new BuilderNullException(nameof(FileShowCommandBuilder)));
    }
}