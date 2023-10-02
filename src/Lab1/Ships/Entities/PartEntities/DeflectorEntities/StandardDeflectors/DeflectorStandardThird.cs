using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.DeflectorSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities.StandardDeflectors;

public class DeflectorStandardThird : BaseDeflector
{
    public DeflectorStandardThird()
    {
        DeflectAntimatterFlares = false;
        PhotonsHealth = (int)HealthPointsPhotonsDeflector.PhotonsDeflectorBrokenOrBaseHealth;
        HealthOfDeflector = (int)HealthPointsDeflector.DeflectorThirdHealth;
        PartWeight = (int)WeightOfDeflector.DeflectorThirdWeight;
    }
}