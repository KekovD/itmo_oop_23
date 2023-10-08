using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;

public class SmallAsteroids : BaseSmallAsteroidsAndMeteorites
{
    private const int SmallAsteroidsDamage = 10;
    public SmallAsteroids()
    {
        StandardDamage = SmallAsteroidsDamage;
    }
}