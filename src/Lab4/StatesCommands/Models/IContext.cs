namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public interface IContext
{
    string? Address { get; }
    string? Drive { get; }

    void TransitionToOtherState(string address, string drive);
    void TransitionToOtherState();
    void TransitionToOtherAddress(string address, string drive);
    bool ConnectRequest();
    bool DisconnectRequest();
}