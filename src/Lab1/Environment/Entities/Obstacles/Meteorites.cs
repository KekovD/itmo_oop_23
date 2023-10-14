using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class Meteorites : ObstaclesBase
{
    private const int MeteoritesDamage = 40;

    public Meteorites(int obstaclesCounter)
        : base(obstaclesCounter)
    {
        Damage = MeteoritesDamage;
    }
}