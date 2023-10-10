using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class Meteorites : BaseObstacles, INormalSpace
{
    private const int MeteoritesDamage = 40;

    public Meteorites()
    {
        Damage = MeteoritesDamage;
    }
}