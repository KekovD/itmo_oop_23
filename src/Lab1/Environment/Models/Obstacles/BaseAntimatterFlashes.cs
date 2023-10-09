using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

public abstract class BaseAntimatterFlashes : BaseObstacles, IHighDensitySpaceNebulae
{
    public override void DoingDamage(BaseShip ship)
    {
        if (ship is BaseShipWithDeflector)
        {
            foreach (IAdditionalEquipment equipment in ship.AdditionalEquipment)
            {
                if (equipment is PhotonsDeflectors photonsDeflectors)
                {
                    photonsDeflectors.DamagingPart(Damage);
                    return;
                }
            }
        }

        ship.KillCrew();
    }
}