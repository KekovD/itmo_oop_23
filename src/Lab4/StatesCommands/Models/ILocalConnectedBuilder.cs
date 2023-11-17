using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

public interface ILocalConnectedBuilder
{
    ILocalConnectedBuilder WithContext(IContext context);
    LocalConnected Create();
}