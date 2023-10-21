using System;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Socket.Entities;

public class Socket : SocketBase
{
    public Socket(string name)
    {
        Name = name;
    }

    public override SocketBase Clone()
    {
        if (Name is null)
            throw new CloneNullException(nameof(SocketBase));

        return new Socket((string)Name.Clone());
    }

    public override bool CompareSocket(SocketBase socket)
    {
        if (socket.Name is null)
            throw new CheckerNullException(nameof(CompareSocket));

        if (socket.Name.Equals(Name, StringComparison.Ordinal))
            return true;

        return false;
    }
}