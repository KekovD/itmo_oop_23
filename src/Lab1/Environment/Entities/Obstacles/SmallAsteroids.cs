using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class SmallAsteroids : ObstaclesBase
{
    private const int SmallAsteroidsDamage = 10;

    public SmallAsteroids(int obstaclesCounter)
        : base(obstaclesCounter)
    {
        Damage = SmallAsteroidsDamage;
    }
}