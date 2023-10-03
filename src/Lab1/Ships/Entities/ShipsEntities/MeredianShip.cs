using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities.StandardDeflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class MeredianShip : BaseShipWithDeflector ////TODO: добавить излучатели(смотри тз)
{
    public MeredianShip(int currentMoney, int currentStandardFuelResidue)
        : base(currentMoney)
    {
        ShipHull = new HullSecond();
        ShipStandardTank = new StandardTank(
            (int)CapacityTankStandard.CapacityStandardWalkingShuttle,
            currentStandardFuelResidue);
        ImpulseEngine = new EImpulseEngine();
        ShipDeflector = new DeflectorStandardSecond();
    }
}