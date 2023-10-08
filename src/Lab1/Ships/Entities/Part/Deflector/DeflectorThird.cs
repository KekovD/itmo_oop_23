using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;

public class DeflectorThird : BaseDeflector
{
    public DeflectorThird(bool havePhotons)
        : base(havePhotons)
    {
        HealthOfDeflector = DeflectorThirdHealth;
        PartWeight += DeflectorThirdWeight;
    }
}