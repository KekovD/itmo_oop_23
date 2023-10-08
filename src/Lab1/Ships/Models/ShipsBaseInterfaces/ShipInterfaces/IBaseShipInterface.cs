using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface IBaseShipInterface
{
    BaseHull ShipHull { get; }
    BaseImpulseEngines? ImpulseEngine { get; }
    StandardTank? ShipStandardTank { get; }
    bool ShipAntiNitrinoEmitter { get; }
    int ShipWeight { get; }
    bool ShipAlive { get; }
    bool ShipCrewAlive { get; }
    bool NoJumpEngineStatus { get; }
    void SetNoJumpStatus();
    void CheckShipAlive();
    int ShipImpulseFuelCost(int distance);
    void KillCrew();
}