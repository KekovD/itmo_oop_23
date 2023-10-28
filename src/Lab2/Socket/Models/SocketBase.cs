using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

public abstract class SocketBase : IPrototype<SocketBase>
{
    public string? Name { get; protected init; }

    public abstract SocketBase Clone();

    public abstract bool CompareSocket(SocketBase socket);
}