using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Socket.Entities;

public class Socket : SocketBase
{
    public Socket(string name)
    {
        Name = name;
    }

    public override SocketBase Clone() =>
        new Socket(Name ?? throw new CloneNullException(nameof(SocketBase)));
}