using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Services;

public class ConnectedState : StateBase
{
    public override bool ConnectHandle() => true;

    public override bool DisconnectHandle() => false;
}