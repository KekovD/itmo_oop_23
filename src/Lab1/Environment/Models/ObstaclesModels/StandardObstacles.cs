using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.ObstaclesBaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class StandardObstacles : IDoingDamage
{
    public abstract void DoingDamage(BaseShip ship, int damage);
}