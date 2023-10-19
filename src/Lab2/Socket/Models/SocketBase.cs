using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

public abstract class SocketBase : IPrototype<SocketBase>
{
    public bool SocketValid { get; protected set; } = true;
    public string? Name { get; protected set; }

    public abstract SocketBase Clone();
}