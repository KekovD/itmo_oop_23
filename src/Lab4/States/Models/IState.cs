namespace Itmo.ObjectOrientedProgramming.Lab4.States.Models;

public interface IState
{
    IState MoveToConnected();
    IState MoveToDisconnected();
}