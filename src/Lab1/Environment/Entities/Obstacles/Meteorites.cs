using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class Meteorites : ObstaclesBase, INormalSpace
{
    private const int MeteoritesDamage = 40;

    public Meteorites(int obstaclesCounter)
        : base(obstaclesCounter)
    {
        Damage = MeteoritesDamage;
    }
}