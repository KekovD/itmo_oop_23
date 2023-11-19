using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class TreeGoToCommand : CommandBase
{
    public TreeGoToCommand()
    {
        Characteristics = new CommandFeatures("tree goto", "local", string.Empty);
    }

    public override void Execute(Command request, IContext context) =>
        context.TransitionToOtherAddress(request, context.GetConnectedMode());
}