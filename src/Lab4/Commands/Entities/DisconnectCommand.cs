using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Records.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class DisconnectCommand : ICommand
{
    private readonly IContext _context;

    public DisconnectCommand(IContext context)
    {
        _context = context;
    }

    public void Execute(Command request) => _context.TransitionToOtherState(request);
}