using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public interface IContextBuilder
{
    IContextBuilder WithState(StateBase state);
    Context Create();
}