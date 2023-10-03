using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.DeflectorSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;

public class DeflectorFirst : BaseDeflector
{
    public DeflectorFirst(bool havePhotons)
        : base(havePhotons)
    {
        HealthOfDeflector = (int)HealthPointsDeflector.DeflectorFirstHealth;
        PartWeight += (int)WeightOfDeflector.DeflectorFirstWeight;
    }
}