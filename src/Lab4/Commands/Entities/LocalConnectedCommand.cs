using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class LocalConnectedCommand : CommandBase
{
    public LocalConnectedCommand()
    {
        Characteristics = new CommandFeatures("connect", "local", string.Empty);
    }

    public override void Execute(Command request, IContext context) => context.TransitionToOtherState(request);
}