using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface IBaseShipInterface
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
    int ImpulseFuelConsumption(int distance);
    void KillCrew();
}