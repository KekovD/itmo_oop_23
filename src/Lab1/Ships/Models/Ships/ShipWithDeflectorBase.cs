using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class ShipWithDeflectorBase : ShipBase
{
    public DeflectorBase? Deflector { get; protected init; }

    public override void TakingDamage(ObstaclesBase obstacles)
    {
        if (obstacles is AntimatterFlash)
        {
            PhotonsDeflectors? photonsDeflector = AdditionalEquipment
                .OfType<PhotonsDeflectors>()
                .FirstOrDefault(equipment => equipment.Serviceability);

            if (photonsDeflector is not null)
            {
                photonsDeflector.DamagingPart(obstacles.Damage);
                return;
            }

            KillCrew();
            return;
        }

        if (obstacles is SpaceWhales)
        {
            if (CheckAvailabilityAdditionalEquipment(new AntiNitrinoEmitter()))
                return;
        }

        if (Deflector is null)
            throw new PartOfShipNullException(nameof(Deflector));

        if (Deflector.Serviceability)
        {
            Deflector.DamagingPart(obstacles.Damage);
            Deflector.CheckPartServiceability();
            return;
        }

        if (Hull is null)
            throw new PartOfShipNullException(nameof(Hull));

        Hull.DamagingPart(obstacles.Damage);
        CheckShipAlive();
    }
}