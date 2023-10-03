using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface IShipDeflector
{
    BaseDeflector ShipDeflector { get; }
}