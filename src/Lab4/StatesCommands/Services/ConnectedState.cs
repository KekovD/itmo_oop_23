using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;

public class ConnectedState : StateBase
{
    public override bool ConnectHandle() => true;

    public override bool DisconnectHandle() => false;

    public override StateBase ChangeState() => new DisconnectedState();
}