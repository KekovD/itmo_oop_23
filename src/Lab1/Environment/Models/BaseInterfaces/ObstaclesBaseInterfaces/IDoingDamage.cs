using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.ObstaclesBaseInterfaces;

public interface IDoingDamage
{
    void DoingDamage(BaseShip ship);
}