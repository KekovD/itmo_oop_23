using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;

public class DeflectorFirst : BaseDeflector
{
    public DeflectorFirst(bool havePhotons)
        : base(havePhotons)
    {
        HealthOfDeflector = DeflectorFirstHealth;
        PartWeight += DeflectorFirstWeight;
    }
}