using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.ModeStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;

public class Context : IContext
{
    private readonly IList<IAddressParser> _addressParser = new List<IAddressParser>();
    private readonly IList<IStrategy> _strategies;
    private StateBase _state = new DisconnectedState();

    private Context(
        StateBase? state,
        IList<IStrategy> strategies,
        IList<IAddressParser>? addressParser,
        string? address,
        string? drive,
        IList<Flag>? flags)
    {
        _state = state ?? _state;
        _addressParser = addressParser ?? _addressParser;
        Address = address;
        Drive = drive;
        Flags = flags?.AsReadOnly();
        _strategies = strategies;
    }

    public string? Address { get; private set; }
    public string? Drive { get; private set; }
    public IReadOnlyList<Flag>? Flags { get; private set; }

    public static IContextBuilder Builder() => new ContextBuilder();

    public void TransitionToOtherState(Command request, string connectionMode)
    {
        _state = _state.ChangeState(request);

        if (_state.ConnectHandle())
        {
            TransitionToOtherAddress(request, connectionMode);
            Flags = request.Flags;
        }
    }

    public void TransitionToOtherAddress(Command request, string connectionMode)
    {
        if (_state.ConnectHandle())
        {
            Address = GetFileSystemParser(connectionMode)?.GetAddress(request);
            Drive = GetFileSystemParser(connectionMode)?.GetDrive(request);
        }
    }

    public bool CheckConnectedMode(string mode)
    {
        const string targetValue = "-m";

        return Flags is not null &&
               Flags.Any(flag =>
                   flag.Value.Equals(targetValue, StringComparison.Ordinal) &&
                   flag.Parameter.Equals(mode, StringComparison.Ordinal));
    }

    public string GetConnectedMode() =>
        Flags?.FirstOrDefault(flag => flag.Value.Equals("-m", StringComparison.Ordinal))?.Parameter ?? string.Empty;

    public string GetAbsoluteAddress(string path, string connectionMode)
    {
        IAddressParser? parser = GetFileSystemParser(connectionMode);
        return parser is null ? string.Empty : parser.GetAbsolutePath(path);
    }

    public string GetUniqueFileName(string directory, string fileName, string connectionMode)
    {
        IAddressParser? parser = GetFileSystemParser(connectionMode);
        return parser is null ? string.Empty : parser.GetUniqueName(directory, fileName);
    }

    public bool ConnectRequest() => _state.ConnectHandle();

    public bool DisconnectRequest() => _state.DisconnectHandle();

    public IStrategy? GetStrategy(string strategyFeatures) =>
        _strategies.FirstOrDefault(command => command.CompareCharacteristics(strategyFeatures));

    public IAddressParser? GetFileSystemParser(string connectionMode) =>
        _addressParser.FirstOrDefault(mode => mode.CompareConnectionMode(connectionMode));

    private class ContextBuilder : IContextBuilder
    {
        private readonly IList<IAddressParser> _addressParser = new List<IAddressParser>();
        private readonly IList<IStrategy> _strategies = new List<IStrategy>();
        private string? _address;
        private string? _drive;
        private IList<Flag>? _flags;
        private StateBase? _state;

        public IContextBuilder WithState(StateBase state)
        {
            _state = state;
            return this;
        }

        public IContextBuilder WithMoreAddressParser(IAddressParser addressParser)
        {
            _addressParser.Add(addressParser);
            return this;
        }

        public IContextBuilder WithMoreStrategy(IStrategy strategy)
        {
            _strategies.Add(strategy);
            return this;
        }

        public IContextBuilder WithAddress(string address)
        {
            _address = address;
            return this;
        }

        public IContextBuilder WithDrive(string drive)
        {
            _drive = drive;
            return this;
        }

        public IContextBuilder WithFlags(IList<Flag> flags)
        {
            _flags = flags;
            return this;
        }

        public Context Create() => new(
            _state,
            _strategies,
            _addressParser,
            _address,
            _drive,
            _flags);
    }
}