using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;

public class SpaceWhales : BaseSpaceWhales
{
    public SpaceWhales()
    {
        StandardDamage = SpaceWhalesDamage;
    }
}