using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface IBaseShipWithJumpEngineAndDeflectorInterface
{
    JumpTank? ShipJumpTank { get; }
    BaseJumpEngines? JumpEngine { get; }
    bool EnoughDistanceJump { get; }
    int ShipJumpFuelConsumption(int distance);
    int ShipIJumpFuelCost(int distance);
    void SetFalseEnoughDistanceJump();
}