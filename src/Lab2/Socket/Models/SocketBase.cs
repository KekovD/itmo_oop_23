namespace Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

public abstract class SocketBase
{
    public bool SocketValid { get; protected set; } = true;
    public string? Name { get; protected init; }
}