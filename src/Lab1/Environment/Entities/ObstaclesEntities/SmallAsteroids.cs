﻿using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;

public class SmallAsteroids : BaseSmallAsteroidsAndMeteorites
{
    public SmallAsteroids()
    {
        StandardDamage = (int)ObstructionDamage.SmallAsteroidsDamage;
    }
}