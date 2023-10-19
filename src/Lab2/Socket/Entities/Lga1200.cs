using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Socket.Entities;

public class Lga1200 : SocketBase
{
    private const string Lga1200Name = "Lga1200";

    public Lga1200()
    {
        Name = Lga1200Name;
    }

    public override SocketBase Clone() => new Lga1200();
}