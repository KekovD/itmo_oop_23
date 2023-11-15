using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Services;

public class Context : IContext
{
    private readonly IAddressParser _addressParser;
    private StateBase _state = new DisconnectedState();

    private Context(IAddressParser addressParser, string? address, string? drive, IList<Flag>? flags)
    {
        _addressParser = addressParser;
        Address = address;
        Drive = drive;
        Flags = flags?.AsReadOnly();
    }

    public string? Address { get; protected set; }
    public string? Drive { get; protected set; }
    public IReadOnlyList<Flag>? Flags { get; protected set; }

    public static IContextBuilder Builder() => new ContextBuilder();

    public void TransitionToOtherState(Command request)
    {
        _state = _state.ChangeState(request);

        if (_state.ConnectHandle())
            TransitionToOtherAddress(request);
    }

    public void TransitionToOtherAddress(Command request)
    {
        if (_state.ConnectHandle())
        {
            Address = _addressParser.GetAddress(request);
            Drive = _addressParser.GetDrive(request);
            Flags = request.Flags.AsReadOnly();
        }
    }

    public bool ConnectRequest() => _state.ConnectHandle();

    public bool DisconnectRequest() => _state.DisconnectHandle();

    private class ContextBuilder : IContextBuilder
    {
        private string? _address;
        private string? _drive;
        private IList<Flag>? _flags;
        private IAddressParser? _addressParser;

        public IContextBuilder WithAddressParser(IAddressParser? addressParser)
        {
            _addressParser = addressParser;
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

        public Context Crate() => new(
            _addressParser ?? throw new BuilderNullException(nameof(ContextBuilder)),
            _address,
            _drive,
            _flags);
    }
}