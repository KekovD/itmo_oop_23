using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;

public class ConsoleLocalMode : ModeFlagSubChainLinkBase
{
    private readonly IContext _context;
    private readonly ICommand _command;

    private ConsoleLocalMode(IContext context)
    {
        _context = context;
        _command = new LocalFileConsoleRender(context);
    }

    public static IConsoleModeBuilder Builder() => new ConsoleModeBuilder();

    public override void Handle(Command request)
    {
        const string targetParameter = "console";
        const string targetValue = "-m";
        const string contextParameter = "local";
        const int targetCount = 3;

        if (_context.DisconnectRequest()) Next?.Handle(request);

        if (request.Flags.Any(flag =>
                flag.Value.Equals(targetValue, StringComparison.Ordinal) &&
                flag.Parameter.Equals(targetParameter, StringComparison.Ordinal)) &&
            _context.CheckConnectedMode(contextParameter) &&
            request.Body.Count == targetCount)
            _command.Execute(request);

        Next?.Handle(request);
    }

    private class ConsoleModeBuilder : IConsoleModeBuilder
    {
        private IContext? _context;

        public IConsoleModeBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public ConsoleLocalMode Create() => new(_context ?? throw new BuilderNullException(nameof(ConsoleModeBuilder)));
    }
}