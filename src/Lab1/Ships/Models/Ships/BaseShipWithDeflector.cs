using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class BaseShipWithDeflector : BaseShip, IBaseShipWithDeflector
{
    public BaseDeflector? Deflector { get; protected init; }
}