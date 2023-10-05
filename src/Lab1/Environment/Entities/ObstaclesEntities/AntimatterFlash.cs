using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;

public class AntimatterFlash : BaseAntimatterFlashes
{
    public AntimatterFlash()
    {
        StandardDamage = (int)ObstructionDamage.AntimatterFlash;
    }
}