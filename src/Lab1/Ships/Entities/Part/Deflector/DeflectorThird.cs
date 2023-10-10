using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;

public class DeflectorThird : BaseDeflector
{
    private const int DeflectorThirdHealth = 400;
    private const int DeflectorThirdWeight = 300;

    public DeflectorThird()
    {
        Health = DeflectorThirdHealth;
        PartWeight += DeflectorThirdWeight;
    }
}