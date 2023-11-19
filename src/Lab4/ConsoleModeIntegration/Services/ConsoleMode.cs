using System;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleModeIntegration.Services;

public class ConsoleMode : IConsoleMode
{
    private readonly IContext _context;
    private readonly CommandChainLinkBase _chain;
    private readonly ICommandParser _parser;

    private ConsoleMode(IContext context, CommandChainLinkBase chain, ICommandParser parser)
    {
        _context = context;
        _chain = chain;
        _parser = parser;
    }

    public static IConsoleModeBuilder Builder() => new ConsoleModeBuilder();

    public void EnterConsoleMode()
    {
        CommandProcessing();

        while (_context.ConnectRequest())
        {
            CommandProcessing();
        }
    }

    private void CommandProcessing()
    {
        string? userInput = Console.ReadLine();

        if (userInput is not null &&
            _parser.TryParseConsoleCommand(userInput, out Command command))
        {
            const string valueInput = "Executed";

            _chain.Handle(command)?.Execute(command, _context);
            Console.WriteLine(valueInput);
        }
    }

    private class ConsoleModeBuilder : IConsoleModeBuilder
    {
        private IContext? _context;
        private CommandChainLinkBase? _chain;
        private ICommandParser? _parser;

        public IConsoleModeBuilder WithContext(IContext context)
        {
            _context = context;
            return this;
        }

        public IConsoleModeBuilder WithChain(CommandChainLinkBase chain)
        {
            _chain = chain;
            return this;
        }

        public IConsoleModeBuilder WithCommandParser(ICommandParser parser)
        {
            _parser = parser;
            return this;
        }

        public ConsoleMode Create() => new(
            _context ?? throw new BuilderNullException(nameof(ConsoleModeBuilder)),
            _chain ?? throw new BuilderNullException(nameof(ConsoleModeBuilder)),
            _parser ?? throw new BuilderNullException(nameof(ConsoleModeBuilder)));
    }
}