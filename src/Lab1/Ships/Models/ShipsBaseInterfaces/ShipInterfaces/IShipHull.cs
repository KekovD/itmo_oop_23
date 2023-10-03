using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface IShipHull
{
    BaseHull ShipHull { get; }
}