using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class SpaceWhales : ObstaclesBase
{
    private const int SpaceWhalesDamage = 1000;

    public SpaceWhales(int obstaclesCounter)
        : base(obstaclesCounter)
    {
        Damage = SpaceWhalesDamage;
    }
}