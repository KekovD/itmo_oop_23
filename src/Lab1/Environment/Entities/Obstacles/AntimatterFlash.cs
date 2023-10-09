using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class AntimatterFlash : BaseAntimatterFlashes
{
    public AntimatterFlash()
    {
        Damage = AntimatterFlashesDamage;
    }
}