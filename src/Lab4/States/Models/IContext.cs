using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Models;

public interface IContext
{
    string? Address { get; }
    string? Drive { get; }
    IReadOnlyList<Flag>? Flags { get; }

    void TransitionToOtherState(Command request);
    void TransitionToOtherAddress(Command request);
    bool CheckConnectedMode(string mode);
    string GetAbsoluteAddress(string path);
    bool ConnectRequest();
    bool DisconnectRequest();
}