using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;

public class DeflectorSecond : BaseDeflector
{
    public DeflectorSecond(bool havePhotons)
        : base(havePhotons)
    {
        HealthOfDeflector = DeflectorSecondHealth;
        PartWeight += DeflectorSecondWeight;
    }
}