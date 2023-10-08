﻿using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;

public class Meteorites : BaseSmallAsteroidsAndMeteorites
{
    public Meteorites()
    {
        StandardDamage = MeteoritesDamage;
    }
}