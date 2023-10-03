using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShip : IHaveJumpEngine, IHaveDeflector
{
    public bool HaveJumpEngine { get; protected init; }
    public bool HaveDeflector { get; protected init; }
}