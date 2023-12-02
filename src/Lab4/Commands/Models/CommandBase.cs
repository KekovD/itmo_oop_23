using Itmo.ObjectOrientedProgramming.Lab4.CommandStrategies.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public abstract class CommandBase
{
    protected const int NextIndexIncrement = 1;

    protected CommandBase(CommandRequest request)
    {
        Request = request;
    }

    public CommandRequest? Request { get; }

    public abstract void Execute(IStrategy strategy, IContext context);
    public abstract bool EqualCommand(CommandBase command);
}