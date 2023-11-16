using System;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;

public class DisconnectedState : StateBase
{
    public override bool ConnectHandle() => false;

    public override bool DisconnectHandle() => true;

    public override StateBase ChangeState(Command request)
    {
        const int targetIndex = 0;
        const int targetCount = 1;
        const string targetCommand = "connect";

        if (request.Body.Count >= targetCount &&
            request.Body[targetIndex].Equals(targetCommand, StringComparison.Ordinal))
            return new ConnectedState();

        return this;
    }
}