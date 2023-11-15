using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Services;

public class DisconnectedState : StateBase
{
    public override bool ConnectHandle() => false;

    public override bool DisconnectHandle() => true;
}