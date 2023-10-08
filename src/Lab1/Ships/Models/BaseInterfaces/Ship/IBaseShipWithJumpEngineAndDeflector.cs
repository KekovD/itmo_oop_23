using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Ship;

public interface IBaseShipWithJumpEngineAndDeflector
{
    BaseJumpEngines? JumpEngine { get; }
    bool EnoughDistanceJumpStatus { get; }
    void SetFalseEnoughDistanceJump();
    int JumpFuelPrice(int distance);
}