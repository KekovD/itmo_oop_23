using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.DeflectorSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;

public class DeflectorSecond : BaseDeflector
{
    public DeflectorSecond(bool havePhotons)
        : base(havePhotons)
    {
        HealthOfDeflector = (int)HealthPointsDeflector.DeflectorSecondHealth;
        PartWeight += (int)WeightOfDeflector.DeflectorSecondWeight;
    }
}