using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.DeflectorSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;

public class DeflectorThird : BaseDeflector
{
    public DeflectorThird(bool havePhotons)
        : base(havePhotons)
    {
        HealthOfDeflector = (int)HealthPointsDeflector.DeflectorThirdHealth;
        PartWeight += (int)WeightOfDeflector.DeflectorThirdWeight;
    }
}