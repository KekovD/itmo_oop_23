using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class BaseShipWithDeflector : BaseShip
{
    public BaseDeflector? Deflector { get; protected init; }
}