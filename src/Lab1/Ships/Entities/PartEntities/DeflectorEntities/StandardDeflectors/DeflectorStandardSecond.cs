using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.DeflectorSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities.StandardDeflectors;

public class DeflectorStandardSecond : BaseDeflector
{
    public DeflectorStandardSecond()
    {
        DeflectAntimatterFlares = false;
        PhotonsHealth = (int)HealthPointsPhotonsDeflector.PhotonsDeflectorBrokenOrBaseHealth;
        HealthOfDeflector = (int)HealthPointsDeflector.DeflectorSecondHealth;
        PartWeight = (int)WeightOfDeflector.DeflectorSecondWeight;
    }
}