using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
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
    private readonly IList<StrategyCommandPair> _strategies;

    private ConsoleMode(IContext context, CommandChainLinkBase chain, ICommandParser parser, IList<StrategyCommandPair> strategies)
    {
        _context = context;
        _chain = chain;
        _parser = parser;
        _strategies = strategies;
    }

    public static IConsoleModeBuilder Builder() => new ConsoleModeBuilder();

    public void EnterConsoleMode(string userInput)
    {
        FirstCommand(userInput);

        while (_context.ConnectRequest())
        {
            FurtherCommand();
        }
    }

    private void FirstCommand(string userInput) => CommandProcessing(userInput);

    private void FurtherCommand() => CommandProcessing(Console.ReadLine());

    private void CommandProcessing(string? userInput)
    {
        if (userInput is not null &&
            _parser.TryParseConsoleCommand(userInput, out CommandRequest command))
        {
            CommandBase? concreteCommand = _chain.Handle(command);
            IStrategy? concreteStrategy = GetStrategy(concreteCommand);

            if (concreteStrategy is not null)
            {
                concreteCommand?.Execute(concreteStrategy, _context);
                Console.WriteLine("Execute.");
                return;
            }

            Console.WriteLine("Command not found.");
        }
    }

    private IStrategy? GetStrategy(CommandBase? command) =>
        command is not null ? _strategies.FirstOrDefault(strategies => strategies.Command.EqualCommand(command))?.Strategy : null;

    private class ConsoleModeBuilder : IConsoleModeBuilder
    {
        private readonly List<StrategyCommandPair> _strategies = new List<StrategyCommandPair>();
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

        public IConsoleModeBuilder WithMoreStrategy(CommandBase command, IStrategy strategy)
        {
            _strategies.Add(new StrategyCommandPair(command, strategy));
            return this;
        }

        public ConsoleMode Create() => new(
            _context ?? throw new BuilderNullException($"{nameof(ConsoleModeBuilder)} {nameof(_context)} is null"),
            _chain ?? throw new BuilderNullException($"{nameof(ConsoleModeBuilder)} {nameof(_chain)} is null"),
            _parser ?? throw new BuilderNullException($"{nameof(ConsoleModeBuilder)} {nameof(_parser)} is null"),
            _strategies);
    }
}