using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShipWithDeflector : BaseShip, IBaseShipWithDeflectorInterface
{
    public BaseDeflector Deflector { get; protected init; } = new BaseDeflector(false);
}