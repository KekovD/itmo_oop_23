using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class DisconnectCommand : CommandBase
{
    public DisconnectCommand()
    {
        Characteristics = new CommandFeatures("disconnect", string.Empty, string.Empty);
    }

    public override void Execute(IContext context)
    {
        if (Request is not null)
            context.TransitionToOtherState(Request, context.GetConnectedMode());

        Request = null;
    }
}