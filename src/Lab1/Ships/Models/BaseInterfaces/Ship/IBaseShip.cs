using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Ship;

public interface IBaseShip
{
    BaseHull? Hull { get; }
    BaseImpulseEngines? ImpulseEngine { get; }
    bool AntiNitrinoEmitter { get; }
    int Weight { get; }
    bool ShipAlive { get; }
    bool CrewAlive { get; }
    bool NoJumpEngineStatus { get; }
    void SetFalseNoJumpStatus();
    void CheckShipAlive();
    int ImpulseFuelPrice(int distance);
    void KillCrew();
}