using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

public abstract class SocketBase : IPrototype<SocketBase>
{
    public bool SocketValid { get; protected set; } = true;
    public string? Name { get; protected set; }

    public SocketBase Clone() =>
        new Entities.Socket(this.Name ?? throw new CloneNullException(nameof(SocketBase)));

    public SocketBase CloneWithNewName(string name)
    {
        SocketBase clone = Clone();
        clone.Name = name;

        return clone;
    }
}