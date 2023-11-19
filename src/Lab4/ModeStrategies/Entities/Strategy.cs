using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.ModeStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ModeStrategies.Entities;

public class Strategy : IStrategy
{
    private readonly IList<CommandBase> _commands;
    private readonly string _connectionMode;

    private Strategy(IList<CommandBase> commands, string connectionMode)
    {
        _commands = commands;
        _connectionMode = connectionMode;
    }

    public static IStrategyBuilder Builder() => new StrategyBuilder();

    public CommandBase? CrateCommand(CommandFeatures commandFeatures, Command request) =>
        _commands.FirstOrDefault(command => command.CompareCharacteristics(commandFeatures, request));

    public bool CompareCharacteristics(string connectionMode) =>
        _connectionMode.Equals(connectionMode, StringComparison.Ordinal);

    private class StrategyBuilder : IStrategyBuilder
    {
        private readonly IList<CommandBase> _commands = new List<CommandBase>();
        private string? _connectionMode;

        public IStrategyBuilder WithMoreCommand(CommandBase commandBase)
        {
            _commands.Add(commandBase);
            return this;
        }

        public IStrategyBuilder WithConnectionMode(string connectionMode)
        {
            _connectionMode = connectionMode;
            return this;
        }

        public Strategy Create() => new(
            _commands,
            _connectionMode ?? throw new BuilderNullException(nameof(StrategyBuilder)));
    }
}