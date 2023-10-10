using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class BaseShipWithDeflector : BaseShip
{
    public BaseDeflector? Deflector { get; protected init; }

    public override void TakingDamage(BaseObstacles obstacles)
    {
        if (obstacles is IHighDensitySpaceNebulae)
        {
            foreach (IAdditionalEquipment equipment in AdditionalEquipment)
            {
                if (equipment is PhotonsDeflectors photonsDeflectors)
                {
                    photonsDeflectors.DamagingPart(obstacles.Damage);
                    return;
                }
            }

            KillCrew();
            return;
        }

        if (obstacles is INitrinoParticleNebulae)
        {
            if (CheckAntiNitrinoEmitter())
                return;
        }

        if (Deflector == null) throw new PartOfShipNullException(nameof(Deflector));

        if (Deflector.Serviceability)
        {
            Deflector.DamagingPart(obstacles.Damage);
            Deflector.SetPartServiceability();
            return;
        }

        if (Hull == null) throw new PartOfShipNullException(nameof(Hull));

        Hull.DamagingPart(obstacles.Damage);
        CheckShipAlive();
    }
}