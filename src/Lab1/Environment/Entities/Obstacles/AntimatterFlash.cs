using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;

public class AntimatterFlash : ObstaclesBase, IHighDensitySpaceNebulae
{
    private const int AntimatterFlashesDamage = 1;

    public AntimatterFlash(int obstaclesCounter)
        : base(obstaclesCounter)
    {
        Damage = AntimatterFlashesDamage;
    }
}