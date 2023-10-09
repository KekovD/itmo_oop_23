using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ServiceabilityAndWeightPart;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;

public class PhotonsDeflectors : PartServiceabilityAndWeight, IAdditionalEquipment
{
    private const int PhotonsDeflectorsHealth = 3;

    public PhotonsDeflectors()
    {
        Health = PhotonsDeflectorsHealth;
    }
}