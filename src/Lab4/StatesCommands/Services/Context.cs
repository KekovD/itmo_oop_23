using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;

public class Context : IContext
{
    private StateBase _state = new DisconnectedState();

    private Context(StateBase? state)
    {
        _state = state ?? _state;
    }

    public string? Address { get; private set; }
    public string? Drive { get; private set; }

    public static IContextBuilder Builder() => new ContextBuilder();

    public void TransitionToOtherState(string address, string drive)
    {
        _state = _state.ChangeState();

        if (_state.ConnectHandle())
        {
            TransitionToOtherAddress(address, drive);
        }
    }

    public void TransitionToOtherState()
    {
        if (_state.ConnectHandle())
            _state = _state.ChangeState();
    }

    public void TransitionToOtherAddress(string address, string drive)
    {
        if (_state.ConnectHandle())
        {
            Address = address;
            Drive = drive;
        }
    }

    public bool ConnectRequest() => _state.ConnectHandle();

    public bool DisconnectRequest() => _state.DisconnectHandle();

    private class ContextBuilder : IContextBuilder
    {
        private StateBase? _state;

        public IContextBuilder WithState(StateBase state)
        {
            _state = state;
            return this;
        }

        public Context Create() => new(_state);
    }
}