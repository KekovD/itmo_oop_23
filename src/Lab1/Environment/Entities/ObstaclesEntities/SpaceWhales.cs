using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;

public class SpaceWhales : BaseSpaceWhales
{
    private const int SpaceWhalesDamage = 1000;
    public SpaceWhales()
    {
        StandardDamage = SpaceWhalesDamage;
    }
}