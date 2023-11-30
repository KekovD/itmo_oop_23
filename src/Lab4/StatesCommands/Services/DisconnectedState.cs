using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;

public class DisconnectedState : StateBase
{
    public override bool ConnectHandle() => false;

    public override bool DisconnectHandle() => true;

    public override StateBase ChangeState() => new ConnectedState();
}