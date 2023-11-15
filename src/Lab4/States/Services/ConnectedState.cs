using System;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Services;

public class ConnectedState : StateBase
{
    public override bool ConnectHandle() => true;

    public override bool DisconnectHandle() => false;

    public override StateBase ChangeState(Command request)
    {
        const int targetIndex = 0;
        const int targetCount = 1;
        const string targetCommand = "disconnect";

        if (request.Body.Count >= targetCount &&
            request.Body[targetIndex].Equals(targetCommand, StringComparison.Ordinal))
            return new DisconnectedState();

        return this;
    }
}