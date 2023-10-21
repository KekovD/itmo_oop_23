using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Socket.Entities;

public class Lga1700 : SocketBase
{
    private const string Lga1700Name = "Lga1700";

    public Lga1700()
    {
        Name = Lga1700Name;
    }

    public override SocketBase Clone() => new Lga1700();

    public override bool CompareSocket(SocketBase socket)
    {
        if (socket is Lga1700)
            return true;

        return false;
    }
}