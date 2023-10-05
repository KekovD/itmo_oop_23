using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;

public class SpaceWhales : BaseSpaceWhales
{
    public SpaceWhales()
    {
        StandardDamage = (int)ObstructionDamage.SpaceWhaleDamage;
    }
}