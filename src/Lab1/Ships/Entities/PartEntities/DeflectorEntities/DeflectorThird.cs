using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;

public class DeflectorThird : BaseDeflector
{
    public DeflectorThird(bool havePhotons)
        : base(havePhotons)
    {
        HealthOfDeflector = DeflectorThirdHealth;
        PartWeight += DeflectorThirdWeight;
    }
}