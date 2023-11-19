using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalConnectedCommand : CommandBase
{
    public LocalConnectedCommand()
    {
        Characteristics = new CommandFeatures("connect", "local", string.Empty);
    }

    public override void Execute(IContext context)
    {
        if (Characteristics is not null && Request is not null)
            context.TransitionToOtherState(Request, Characteristics.ConnectionMode);

        Request = null;
    }
}