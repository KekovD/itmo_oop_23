using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Models;

public interface IContext
{
    string? Address { get; }
    string? Drive { get; }
    IReadOnlyList<Flag>? Flags { get; }

    public void Transition(Command request);
    bool ConnectRequest();
    bool DisconnectRequest();
}