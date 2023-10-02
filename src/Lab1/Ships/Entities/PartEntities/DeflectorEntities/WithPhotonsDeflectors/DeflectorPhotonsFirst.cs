using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.DeflectorSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities.WithPhotonsDeflectors;

public class DeflectorPhotonsFirst : BaseDeflector
{
    public DeflectorPhotonsFirst()
    {
        DeflectAntimatterFlares = true;
        PhotonsHealth = (int)HealthPointsPhotonsDeflector.PhotonsDeflectorsHealth;
        HealthOfDeflector = (int)HealthPointsDeflector.DeflectorFirstHealth;
        PartWeight = (int)WeightOfDeflector.DeflectorFirstWeight + (int)WeightOfDeflector.DeflectorPhotonWeight;
    }
}