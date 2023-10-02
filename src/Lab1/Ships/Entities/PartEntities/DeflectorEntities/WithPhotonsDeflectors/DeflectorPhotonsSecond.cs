using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.DeflectorSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities.WithPhotonsDeflectors;

public class DeflectorPhotonsSecond : BaseDeflector
{
    public DeflectorPhotonsSecond()
    {
        DeflectAntimatterFlares = true;
        PhotonsHealth = (int)HealthPointsPhotonsDeflector.PhotonsDeflectorsHealth;
        HealthOfDeflector = (int)HealthPointsDeflector.DeflectorSecondHealth;
        PartWeight = (int)WeightOfDeflector.DeflectorSecondWeight + (int)WeightOfDeflector.DeflectorPhotonWeight;
    }
}