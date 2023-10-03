using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface IShipImpulseEngine : IShipStandardTank
{
    BaseImpulseEngines ImpulseEngine { get; }
}