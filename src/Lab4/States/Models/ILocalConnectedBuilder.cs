using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.States.Models;

public interface ILocalConnectedBuilder
{
    ILocalConnectedBuilder WithContext(IContext context);
    LocalConnected Crate();
}