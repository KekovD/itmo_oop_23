namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public abstract class StateBase
{
    public abstract bool ConnectHandle();
    public abstract bool DisconnectHandle();

    public abstract StateBase ChangeState();
}