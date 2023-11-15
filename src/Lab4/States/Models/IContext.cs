using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Models;

public interface IContext
{
    string? Address { get; }
    string? Drive { get; }
    IReadOnlyList<Flag>? Flags { get; }

    void TransitionTo(StateBase state, Command request);

    bool ConnectRequest();
    bool DisconnectRequest();
}