using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface IBaseShipWithJumpEngineAndDeflectorInterface
{
    BaseJumpEngines? JumpEngine { get; }
    bool EnoughDistanceJump { get; }
    void SetFalseEnoughDistanceJump();
    int JumpFuelPrice(int distance);
}