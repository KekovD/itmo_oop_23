namespace Itmo.ObjectOrientedProgramming.Lab4.States.Models;

public abstract class StateBase
{
    protected IContext? Context { get; private set; }

    public void SetContext(IContext context)
    {
        Context = context;
    }

    public abstract bool ConnectHandle();
    public abstract bool DisconnectHandle();
}