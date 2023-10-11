using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class SmallAsteroids : ObstaclesBase, INormalSpace
{
    private const int SmallAsteroidsDamage = 10;

    public SmallAsteroids()
    {
        Damage = SmallAsteroidsDamage;
    }
}