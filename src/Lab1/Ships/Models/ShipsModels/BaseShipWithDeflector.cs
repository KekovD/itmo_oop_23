using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShipWithDeflector : BaseShip, IBaseShipWithDeflector
{
    public BaseDeflector Deflector { get; protected init; } = new BaseDeflector(false);
}