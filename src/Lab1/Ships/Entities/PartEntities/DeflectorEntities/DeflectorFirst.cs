using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;

public class DeflectorFirst : BaseDeflector
{
    public DeflectorFirst(bool havePhotons)
        : base(havePhotons)
    {
        HealthOfDeflector = DeflectorFirstHealth;
        PartWeight += DeflectorFirstWeight;
    }
}