using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;

public class AntimatterFlash : BaseAntimatterFlashes
{
    private const int AntimatterFlashesDamage = 1;
    public AntimatterFlash()
    {
        StandardDamage = AntimatterFlashesDamage;
    }
}