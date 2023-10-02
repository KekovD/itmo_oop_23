using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.DeflectorSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities.WithPhotonsDeflectors;

public class DeflectorPhotonsThird : BaseDeflector
{
    public DeflectorPhotonsThird()
    {
        DeflectAntimatterFlares = true;
        PhotonsHealth = (int)HealthPointsPhotonsDeflector.PhotonsDeflectorsHealth;
        HealthOfDeflector = (int)HealthPointsDeflector.DeflectorThirdHealth;
        PartWeight = (int)WeightOfDeflector.DeflectorThirdWeight + (int)WeightOfDeflector.DeflectorPhotonWeight;
    }
}