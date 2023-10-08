﻿using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;

public interface IObstacles
{
    int Damage { get; }
    void DoingDamage(BaseShip ship);
}