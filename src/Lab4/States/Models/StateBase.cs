using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;

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

    public abstract StateBase ChangeState(Command request);
}